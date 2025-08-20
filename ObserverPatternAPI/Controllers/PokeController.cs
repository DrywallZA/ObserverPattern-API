using Microsoft.AspNetCore.Mvc;
using ObserverPatternAPI.Interfaces;

namespace ObserverPatternAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokeController : ControllerBase
    {
        private readonly IPokeObservable _observable;

        public PokeController(IPokeObservable observable)
        {
            _observable = observable;
        }

        [HttpGet(Name = "GetPokemon")]
        public async Task<string> GetPokemon()
        {
            var a = _observable.GetPokemon();
            return default;
        }

    }
}