using Microsoft.AspNetCore.Mvc;
using skm_back_dotnet.Entities;
using skm_back_dotnet.Services;

namespace skm_back_dotnet.Controllers
{
    [Route("api/genres")]
    public class GenresController: ControllerBase
    {
        private readonly IRepository repository;

        public GenresController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> Get(){
            return await repository.GetAllGenres();
        }

        [HttpGet("{Id:int}")]
        public ActionResult<Genre> Get(int Id){
            var genre = repository.GetGenreById(Id);
            if(genre == null){
                return NotFound(); 
            }
            return genre;
        }

        [HttpPost]
        public ActionResult Post(){
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put(){
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(){
            return NoContent();
        }

    }
}