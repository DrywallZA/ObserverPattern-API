using Microsoft.AspNetCore.Mvc;

namespace ObserverPatternAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokeController : ControllerBase
    {

        [HttpGet(Name = "GetPokemon")]
        public async Task<string> GetPokemon()
        {
            var a = GetPokemon();
            return default;
        }

    }
}