using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using skm_back_dotnet.Entities;
using skm_back_dotnet.Services;
using skm_back_dotnet.Filters;

namespace skm_back_dotnet.Controllers
{
    [Route("api/genres")]
    [ApiController]         //Força a inferencia binding-parametros-modelstate(valid) automaticamente
    public class GenresController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly ILogger<GenresController> logger;

        public GenresController(IRepository repository, ILogger<GenresController> logger)
        {
            this.logger = logger;
            this.repository = repository;
        }

        //Níveis de log: Critical - Error - Warning - Information - Debug - Trace
        //Configuramos o namespace e o nível de log em appsettings.json (ou development)
        //Podemos configurar providers de erro(saida) em Program.cs em ConfigureWebHostsDefaults

        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ServiceFilter(typeof(TheActionFilter))]            //Não esquecer de registrar filtro em Startup - ConfigureServices
        public async Task<ActionResult<List<Genre>>> Get()
        {
            logger.LogInformation("Consultando todos os gênreros");
            return await repository.GetAllGenres();
        }

        [HttpGet("{Id:int}")]
        [ServiceFilter(typeof(TheActionFilter))]  
        public ActionResult<Genre> Get(int Id)
        {
            logger.LogDebug("GetGenreById será executado");
            var genre = repository.GetGenreById(Id);
            if (genre == null)
            {
                logger.LogWarning($"Gênero com Id {Id} não encontrado");
                //throw new ApplicationException();
                return NotFound();
            }
            return genre;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genre genre)
        {
            repository.AddGenre(genre);
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put()
        {
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }

    }
}