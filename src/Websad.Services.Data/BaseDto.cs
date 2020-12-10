using System.Collections.Generic;
using Websad.Core.Extensions;

namespace Websad.Services.Data
{
    public class ViewListDto<T> where T: class {

        public ViewListDto() {
            Items = new List<T>();
        }

        public ViewListDto(ICollection<T> items) {
            items.CheckArgumentIsNull(nameof(items));
            Items = items;
        }

        public ICollection<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageCount => TotalCount / PageSize;
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        
    }

    public class ViewListParam<T> where T:class {
        public T Filter { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Skip => PageSize * PageIndex;
    }
}
