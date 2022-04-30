using skm_back_dotnet.Entities;

namespace skm_back_dotnet.Services
{
    public interface IRepository
    {
         public Task<List<Genre>> GetAllGenres();
         public Genre GetGenreById(int Id);
    }
}