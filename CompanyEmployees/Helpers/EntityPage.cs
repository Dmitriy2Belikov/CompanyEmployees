using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CompanyEmployees.Helpers
{
    public class EntityPage<TValue>
        where TValue : class
    {
        public IEnumerable<TValue> Items { get; }
        public int PageNumber { get; }
        public int PageCount { get; }

        public EntityPage(IEnumerable<TValue> value, int pagenumber, int pagecount)
        {
            Items = value;
            PageNumber = pagenumber;
            PageCount = pagecount;
        }
    }
}
