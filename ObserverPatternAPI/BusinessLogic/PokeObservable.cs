using System.Text.Json;
using ObserverPatternAPI.Interfaces;

namespace ObserverPatternAPI.BusinessLogic
{
    public class PokeObservable : IObservable
    {
        private readonly HttpClient _httpClient;

        //TODO Remember to constuct this via the Program.cs
        public PokeObservable(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");

        }

        public async Task<string> GetPokemon()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("https://pokeapi.co/api/v2/");
                var parsedJsonDoc = JsonDocument.Parse(response);
                // var completeQuote = parsedJsonDoc.RootElement.GetProperty("quote").GetString() ?? "No quote available";

                // return completeQuote;
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