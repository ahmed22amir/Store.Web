using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Helper
{
    public class PaginatedResultDto<T>
    {
        public PaginatedResultDto(int? pageSize, int? pageIndex, int? totalCount, IReadOnlyList<T> date)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalCount = totalCount;
            Date = date;
        }

        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        public int? TotalCount { get; set; }
        public IReadOnlyList<T> Date { get; set; }
    }
}
