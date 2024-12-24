using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Responses
{
    public class PaginatedResponse<T>
    {
        public PaginatedResponse(IList<T> datas, int pageNumber, int pageSize, int totalCount, IList<T> otherdatas = default)
        {
            Datas = datas;
            Otherdatas = otherdatas;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling((double)totalCount/pageSize);
            IsFirstPage = PageNumber == 1;
            IsLastPage = PageNumber == TotalPages;
        }

        public IList<T> Datas { get; set; }
        public IList<T> Otherdatas { get;set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages {  get; set; }
        public bool IsFirstPage {  get; set; }
        public bool IsLastPage { get; set; }

    }
}
