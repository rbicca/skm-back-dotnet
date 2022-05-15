using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace skm_back_dotnet.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task InsertParametersPaginationInHeader<T>(this HttpContext httpContext, IQueryable<T> queryable){

            if(httpContext == null){ throw new ArgumentNullException(nameof(httpContext)); }

            double count = await queryable.CountAsync();
            httpContext.Response.Headers.Add("totalAmountOfRecords", count.ToString());
        }
    }
}