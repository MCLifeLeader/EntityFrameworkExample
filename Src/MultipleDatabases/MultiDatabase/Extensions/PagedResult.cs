using System.Collections.Generic;

namespace MultiDatabase.Extensions
{
    /// <summary>
    /// https://www.codingame.com/playgrounds/5363/paging-with-entity-framework-core
    /// </summary>
    /// <typeparam name="T"></typeparam>
    // ReSharper disable once InconsistentNaming
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}