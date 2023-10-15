using System.Collections.Immutable;
using Newtonsoft.Json;
using Server.Interfaces;
using Server.Models;

namespace Server.Services
{
    public class StarWarsService : IStarWars
    {
        private readonly HttpClient _httpClient;
        private string swapiAPIUrl = "https://swapi.dev/api/people";

        public StarWarsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ImmutableList<Character>> GetStarWarsPeopleNamesAsync()
        {
            ImmutableList<Character> characters = ImmutableList<Character>.Empty;
            bool loading = true;
            try
            {
                while (loading)
                {
                    try
                    {
                        var httpResponse = await _httpClient.GetAsync(swapiAPIUrl);
                        httpResponse.EnsureSuccessStatusCode();

                        string response = await httpResponse.Content.ReadAsStringAsync();
                        var swapiResponse = JsonConvert.DeserializeObject<SwapiResponse>(response);

                        characters = characters.AddRange(swapiResponse.Results);

                        if (!string.IsNullOrEmpty(swapiResponse.Next))
                        {
                            swapiAPIUrl = swapiResponse.Next;
                        }
                        else
                        {
                            loading = false;
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred { ex.Message}");
            }
            return characters;

        }
    }
}
