using Microsoft.AspNetCore.Mvc;
using ObserverPatternAPI.Factories;
using ObserverPatternAPI.Interfaces;

namespace ObserverPatternAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokeController : ControllerBase
    {
        private readonly IPokeObservable _observable;
        private readonly ObserverFactory _observerFactory;

        public PokeController(IPokeObservable observable, ObserverFactory observerFactory)
        {
            _observable = observable;
            _observerFactory = observerFactory;
            _observerFactory.InitializeObservers();
        }

        [HttpGet(Name = "GetPokemon")]
        public async Task<string> GetPokemon()
        {
            return await _observable.GetPokemon();
        }
    }
}