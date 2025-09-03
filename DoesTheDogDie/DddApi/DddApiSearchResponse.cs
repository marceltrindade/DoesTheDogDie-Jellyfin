
using System.Collections.Generic;

namespace DoesTheDogDie.DddApi
{
    public class DddApiSearchResponse
    {
        public List<DddApiSearchItem> Items { get; set; }
    }

    public class DddApiSearchItem
    {
        public int Id { get; set; }
    }
}
