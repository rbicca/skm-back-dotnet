using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skm_back_dotnet.DTOs;

namespace skm_back_dotnet.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public ActorsController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get(){
            var actors = await context.Actors.ToListAsync();
            return mapper.Map<List<ActorDTO>>(actors);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ActorDTO>> Get(int id){
            var actor = await context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if(actor == null){
                return NotFound();
            }
            return mapper.Map<ActorDTO>(actor);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActorCreationDTO actorCreationDTO){
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromForm] ActorCreationDTO actorCreationDTO){
            throw new NotImplementedException();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id){
            var actor = await context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if (actor == null){
                return NotFound();
            }

            context.Remove(actor);
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}