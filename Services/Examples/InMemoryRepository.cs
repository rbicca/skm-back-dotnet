// using skm_back_dotnet.Entities;

// namespace skm_back_dotnet.Services
// {
//     public class InMemoryRepository: IRepository
//     {
//         private List<Genre> _genres;
        
//         public InMemoryRepository()
//         {
//             _genres = new List<Genre>(){
//                 new Genre(){Id = 1, Name="Comédia"},
//                 new Genre(){Id = 2, Name="SyFi"},
//                 new Genre(){Id = 3, Name="Aventura"},
//                 new Genre(){Id = 3, Name="Romance"}
//             };
//         }

//         public async Task<List<Genre>> GetAllGenres(){
//             await Task.Delay(1);
//             return _genres;
//         }

//         public Genre GetGenreById(int Id){
//             return _genres.FirstOrDefault(i => i.Id == Id);
//         }

//         public void AddGenre(Genre genre){
//             genre.Id = _genres.Max(x => x.Id) + 1;
//             _genres.Add(genre);
//         }
//     }
// }