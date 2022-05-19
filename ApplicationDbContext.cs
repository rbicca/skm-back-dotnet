
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using skm_back_dotnet.Entities;

namespace skm_back_dotnet
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        
    }
}



// dotnet ef migrations add Initial

// dotnet ef database update
