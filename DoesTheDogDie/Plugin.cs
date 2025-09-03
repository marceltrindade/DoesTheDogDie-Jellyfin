using System;
using System.Collections.Generic;
using System.Net.Http;
using DoesTheDogDie.ScheduledTasks;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Controller.Library;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using MediaBrowser.Model.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DoesTheDogDie
{
    public class Plugin : BasePlugin<PluginConfiguration>
    {
        private readonly ILibraryManager _libraryManager;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ScanLibraryTask> _scanTaskLogger;

        public static Plugin Instance { get; private set; }

        public override string Name => "Does the Dog Die Integration";

        public override Guid Id => Guid.Parse("0b881525-a8f2-416b-9b3b-10ab164cd3c8");

        public Plugin(
            IApplicationPaths applicationPaths,
            IXmlSerializer xmlSerializer,
            ILibraryManager libraryManager,
            IHttpClientFactory httpClientFactory,
            ILogger<ScanLibraryTask> scanTaskLogger)
            : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
            _libraryManager = libraryManager;
            _httpClientFactory = httpClientFactory;
            _scanTaskLogger = scanTaskLogger;
        }

        public IEnumerable<IScheduledTask> GetScheduledTasks()
        {
            return new[]
            {
                new ScanLibraryTask(_libraryManager, _httpClientFactory, _scanTaskLogger)
            };
        }
    }
}