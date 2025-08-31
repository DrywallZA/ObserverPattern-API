namespace ObserverPatternAPI.Interfaces
{
    public interface IPokeObservable
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObserver(List<string> data);

        Task<string> GetPokemon();
    }
}