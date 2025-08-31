using ObserverPatternAPI.Interfaces;

namespace ObserverPatternAPI.Observers
{
    public class SquirtleObserver : IObserver
    {
        private readonly IPokeObservable _pokeObservable;

        public SquirtleObserver(IPokeObservable pokeObservable)
        {
            _pokeObservable = pokeObservable;
            _pokeObservable.RegisterObserver(this);
        }

        public void Update(List<string> pokemonData)
        {
            throw new NotImplementedException();
        }
    }
}