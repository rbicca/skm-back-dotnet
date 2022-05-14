using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using skm_back_dotnet.Entities;
using skm_back_dotnet.Filters;

namespace skm_back_dotnet.Controllers
{
    [Route("api/genres")]
    [ApiController]         //Força a inferencia binding-parametros-modelstate(valid) automaticamente
    public class GenresController : ControllerBase
    {
        private readonly ILogger<GenresController> logger;

        public GenresController(ILogger<GenresController> logger)
        {
            this.logger = logger;
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
            return new List<Genre>(){ new Genre(){ Id=1, Name="Comédia" } };
        }

        [HttpGet("{Id:int}")]
        //[ServiceFilter(typeof(TheActionFilter))]  
        public ActionResult<Genre> Get(int Id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genre genre)
        {
            throw new NotImplementedException();
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