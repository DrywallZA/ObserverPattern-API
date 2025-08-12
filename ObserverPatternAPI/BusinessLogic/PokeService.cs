using System.Text.Json;

namespace ObserverPatternAPI.BusinessLogic
{
    public class PokeService
    {
        private readonly HttpClient _httpClient;

        //TODO Remember to constuct this via the Program.cs
        public PokeService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            // _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");

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
    }

}