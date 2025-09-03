
using MediaBrowser.Model.Plugins;

namespace DoesTheDogDie
{
    public class PluginConfiguration : BasePluginConfiguration
    {
        public string ApiKey { get; set; }
        public string Triggers { get; set; }
    }
}
