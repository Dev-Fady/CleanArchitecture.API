using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Extentions
{
    public static class Pagination
    {
        public static List<T> Paginate<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
           return query.
                Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToList();
        }
    }
    public class PaginateBaseParamter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginateBaseParamter()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public PaginateBaseParamter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

    }
}
