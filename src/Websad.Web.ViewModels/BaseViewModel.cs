using System.Collections.Generic;

namespace Websad.Web.ViewModels
{
    public class ListViewBaseViewModel<T> where T:class {

        public ListViewBaseViewModel() {
            Items = new List<T>();
        }

        public IEnumerable<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int PageNum => PageIndex + 1;
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int PageCount => getTotalPageCount();
        public int NextPageNum => PageNum + 1;
        public int PrevPageNum => PageNum - 1;

        private int getTotalPageCount() {
            var cnt = (TotalCount / PageSize);
            return cnt > 0 ? cnt : 1;
        }
    }

    
}
