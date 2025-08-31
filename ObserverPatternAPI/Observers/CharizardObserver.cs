using ObserverPatternAPI.Interfaces;

namespace ObserverPatternAPI.Observers
{
    public class CharizardObserver : IObserver
    {
        private readonly IPokeObservable _pokeObservable;

        public CharizardObserver(IPokeObservable pokeObservable)
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