using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DoesTheDogDie.DddApi;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Entities.Movies;
using MediaBrowser.Controller.Library;
using MediaBrowser.Model.Entities;
using MediaBrowser.Model.Tasks;
using Jellyfin.Data.Enums;
using Microsoft.Extensions.Logging;

namespace DoesTheDogDie.ScheduledTasks
{
    public class ScanLibraryTask : IScheduledTask
    {
        private readonly ILibraryManager _libraryManager;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ScanLibraryTask> _logger;

        public ScanLibraryTask(ILibraryManager libraryManager, IHttpClientFactory httpClientFactory, ILogger<ScanLibraryTask> logger)
        {
            _libraryManager = libraryManager;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public string Name => "Scan library for triggers";

        public string Key => "DoesTheDogDieScanLibrary";

        public string Description => "Scans the library and applies content warnings from Does The Dog Die?.In";

        public string Category => "Library";

        public Task ExecuteAsync(IProgress<double> progress, CancellationToken cancellationToken)
        {
            return ExecuteCoreAsync(progress, cancellationToken);
        }

        private async Task ExecuteCoreAsync(IProgress<double> progress, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting Does The Dog Die library scan.");

            var config = Plugin.Instance.Configuration;
            if (string.IsNullOrEmpty(config.ApiKey))
            {
                _logger.LogError("API Key for Does The Dog Die is not configured. Skipping scan.");
                return;
            }

            var triggersToBlock = new HashSet<string>(config.Triggers?.Split('\n', StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>(), StringComparer.OrdinalIgnoreCase);
            if (triggersToBlock.Count == 0)
            {
                _logger.LogInformation("No triggers configured to block. Skipping scan.");
                return;
            }

            var movies = _libraryManager.GetItemList(
                new InternalItemsQuery
                {
                    IncludeItemTypes = new[] { BaseItemKind.Movie },
                    IsVirtualItem = false,
                    HasImdbId = true
                }).Cast<Movie>().ToList();

            _logger.LogInformation("Found {0} movies with IMDb IDs to scan.", movies.Count);
            progress.Report(0);

            for (int i = 0; i < movies.Count; i++)
            {
                var movie = movies[i];
                cancellationToken.ThrowIfCancellationRequested();

                var imdbId = movie.GetProviderId(MetadataProvider.Imdb);
                _logger.LogInformation("Scanning movie: {0} (IMDb: {1})", movie.Name, imdbId);

                try
                {
                    var client = _httpClientFactory.CreateClient();
                    client.DefaultRequestHeaders.Add("X-API-KEY", config.ApiKey);

                    // Step 1: Search for the item by IMDb ID to get the DDD item ID
                    var searchUrl = $"https://www.doesthedogdie.com/dddsearch?imdb={imdbId}";
                    var searchResponse = await client.GetAsync(searchUrl, cancellationToken);

                    if (!searchResponse.IsSuccessStatusCode)
                    {
                        _logger.LogError("Failed to search for movie {0} on DDD. Status: {1}", movie.Name, searchResponse.StatusCode);
                        continue;
                    }

                    var searchContent = await searchResponse.Content.ReadAsStringAsync();
                    var searchResult = JsonSerializer.Deserialize<DddApiSearchResponse>(searchContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    var dddItem = searchResult?.Items?.FirstOrDefault();
                    if (dddItem == null)
                    {
                        _logger.LogInformation("Movie {0} not found on Does The Dog Die.", movie.Name);
                        continue;
                    }

                    // Step 2: Get media details using the DDD item ID
                    var mediaUrl = $"https://www.doesthedogdie.com/media/{dddItem.Id}";
                    var mediaResponse = await client.GetAsync(mediaUrl, cancellationToken);

                    if (!mediaResponse.IsSuccessStatusCode)
                    {
                        _logger.LogError("Failed to get media details for {0} from DDD. Status: {1}", movie.Name, mediaResponse.StatusCode);
                        continue;
                    }

                    var mediaContent = await mediaResponse.Content.ReadAsStringAsync();
                    var mediaResult = JsonSerializer.Deserialize<DddApiMediaResponse>(mediaContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    bool hasTrigger = false;
                    foreach (var stat in mediaResult?.TopicItemStats ?? Enumerable.Empty<DddApiTopicItemStat>())
                    {
                        if (stat.Topic != null && triggersToBlock.Contains(stat.Topic.Name) && stat.YesSum > stat.NoSum)
                        {
                            _logger.LogInformation("Found trigger '{0}' for movie {1}", stat.Topic.Name, movie.Name);
                            hasTrigger = true;
                            break;
                        }
                    }

                    if (hasTrigger)
                    {
                        if (!movie.Tags.Contains("DTDD-Bloqueado"))
                        {
                            var newTags = movie.Tags.Append("DTDD-Bloqueado").ToArray();
                            movie.Tags = newTags;
                            await movie.UpdateToRepositoryAsync(ItemUpdateType.MetadataEdit, cancellationToken).ConfigureAwait(false);
                            _logger.LogInformation("Applied 'DTDD-Bloqueado' tag to {0}", movie.Name);
                        }
                        else
                        {
                            _logger.LogInformation("'DTDD-Bloado' tag already exists on {0}", movie.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing movie {0}", movie.Name);
                }

                progress.Report((double)(i + 1) / movies.Count * 100);
            }

            _logger.LogInformation("Does The Dog Die library scan finished.");
        }

        public IEnumerable<TaskTriggerInfo> GetDefaultTriggers()
        {
            return new[]
            {
                new TaskTriggerInfo
                {
                    Type = TaskTriggerInfo.TriggerDaily,
                    TimeOfDayTicks = TimeSpan.FromHours(2).Ticks
                }
            };
        }
    }
}