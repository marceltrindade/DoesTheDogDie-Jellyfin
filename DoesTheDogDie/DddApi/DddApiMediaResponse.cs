
using System.Collections.Generic;

namespace DoesTheDogDie.DddApi
{
    public class DddApiMediaResponse
    {
        public List<DddApiTopicItemStat> TopicItemStats { get; set; }
    }

    public class DddApiTopicItemStat
    {
        public int YesSum { get; set; }
        public int NoSum { get; set; }
        public DddApiTopic Topic { get; set; }
    }

    public class DddApiTopic
    {
        public string Name { get; set; }
    }
}
