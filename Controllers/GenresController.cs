using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skm_back_dotnet.Entities;
using skm_back_dotnet.Filters;

namespace skm_back_dotnet.Controllers
{
    [Route("api/genres")]
    [ApiController]         //Força a inferencia binding-parametros-modelstate(valid) automaticamente
    public class GenresController : ControllerBase
    {
        private readonly ILogger<GenresController> logger;
        private readonly ApplicationDbContext context;

        public GenresController(ILogger<GenresController> logger, ApplicationDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        //Níveis de log: Critical - Error - Warning - Information - Debug - Trace
        //Configuramos o namespace e o nível de log em appsettings.json (ou development)
        //Podemos configurar providers de erro(saida) em Program.cs em ConfigureWebHostsDefaults

        // [HttpGet]
        // //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        // [ServiceFilter(typeof(TheActionFilter))]            //Não esquecer de registrar filtro em Startup - ConfigureServices
        // public async Task<ActionResult<List<Genre>>> Get()
        // {
        //     logger.LogInformation("Consultando todos os gênreros");
        //     return await repository.GetAllGenres();
        // }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> Get(){
            logger.LogInformation("Consultando todos os gênreros");
            
            //return new List<Genre>(){ new Genre(){ Id=1, Name="Comédia" } };

            return await context.Genres.ToListAsync();
        }

        [HttpGet("{Id:int}")]
        //[ServiceFilter(typeof(TheActionFilter))]  
        public ActionResult<Genre> Get(int Id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Genre genre)
        {
            context.Genres.Add(genre);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }

    }
}