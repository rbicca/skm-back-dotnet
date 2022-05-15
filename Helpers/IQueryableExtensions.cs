using skm_back_dotnet.DTOs;
using System.Linq;

namespace skm_back_dotnet.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO paginationDTO){
            return queryable
                .Skip((paginationDTO.Page -1) * paginationDTO.RecordsPerPage)
                .Take(paginationDTO.RecordsPerPage);
        }
    }
}