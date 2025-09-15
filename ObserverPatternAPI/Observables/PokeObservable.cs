using System.Text.Json;
using ObserverPatternAPI.Interfaces;

namespace ObserverPatternAPI.BusinessLogic
{
    public class PokeObservable : IPokeObservable
    {
        private readonly HttpClient _httpClient;
        private readonly List<IObserver> _observers;

        public PokeObservable(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _observers = new List<IObserver>();
        }

        public async Task<string> GetPokemon()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("https://pokeapi.co/api/v2/pokemon/");
                var parsedJsonDoc = JsonDocument.Parse(response);
                var results = parsedJsonDoc.RootElement.GetProperty("results").EnumerateArray();
                var pokemonNames = new List<string>();

                foreach (var result in results)
                {
                    var name = result.GetProperty("name").GetString();

                    if (name != null)
                    {
                        pokemonNames.Add(name);
                    }
                }
                
                NotifyObserver(pokemonNames);

                return "Observers notifed";
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        public void NotifyObserver(List<string> data)
        {
            foreach (var observer in _observers)
            {
                observer.Update(data);
            };
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }
    }

}