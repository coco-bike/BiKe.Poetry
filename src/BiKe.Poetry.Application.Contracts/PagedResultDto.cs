using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BiKe.Poetry
{
    public class PagedResultDto<T> : PagedResult
    {
        public  IEnumerable<T> Rows { get; set; }
    }
}
