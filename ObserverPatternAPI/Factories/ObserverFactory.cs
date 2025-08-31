using ObserverPatternAPI.Interfaces;
using ObserverPatternAPI.Observers;

namespace ObserverPatternAPI.Factories
{
    public class ObserverFactory
    {
        private readonly IPokeObservable _observable;
        
        public ObserverFactory(IPokeObservable pokeObservable)
        {
            _observable = pokeObservable;
        }

        public void InitializeObservers()
        {
            new CharizardObserver(_observable);
            new IvysaurObserver(_observable);
            new SquirtleObserver(_observable);
            new WartortleObserver(_observable);
        }
    }
}