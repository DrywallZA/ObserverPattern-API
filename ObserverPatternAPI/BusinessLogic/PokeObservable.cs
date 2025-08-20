using System.Text.Json;
using ObserverPatternAPI.Interfaces;

namespace ObserverPatternAPI.BusinessLogic
{
    public class PokeObservable : IPokeObservable
    {
        private readonly HttpClient _httpClient;

        public PokeObservable(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

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

                //TODO Notify your observers depending on the Pokemon
                var a = 1;
                return default;
            }
            catch (System.Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        public void NotifyObserver()
        {
            throw new NotImplementedException();
        }

        public void RegisterObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void RemoveObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        private void GetPokemonFromAPI()
        { }
    }

}