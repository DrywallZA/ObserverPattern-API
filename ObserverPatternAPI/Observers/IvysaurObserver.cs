using ObserverPatternAPI.Interfaces;

namespace ObserverPatternAPI.Observers
{
    public class IvysaurObserver : IObserver
    {
        private readonly IPokeObservable _pokeObservable;

        public IvysaurObserver(IPokeObservable pokeObservable)
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