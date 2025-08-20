namespace ObserverPatternAPI.Interfaces
{
    public interface IPokeObservable
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObserver();

        Task<string> GetPokemon();
    }
}