using System.Collections.Immutable;
using Newtonsoft.Json;
using Server.Interfaces;
using Server.Models;

namespace Server.Services
{
    public class StarWarsImageService : IStarWarsImage
    {
        private readonly HttpClient _httpClient;
        private readonly string url = "https://akabab.github.io/starwars-api/api/all.json";

        public StarWarsImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ImmutableList<StarWarsImage>> GetStarWarsPeopleNamesWithImagesAsync()
        {
            ImmutableList<StarWarsImage> characters = ImmutableList<StarWarsImage>.Empty;
            try
            {
                try
                {
                    var httpResponse = await _httpClient.GetAsync(url);
                    httpResponse.EnsureSuccessStatusCode();

                    string response = await httpResponse.Content.ReadAsStringAsync();

                    var deserializedObject = JsonConvert.DeserializeObject<List<StarWarsImage>>(response);

                    characters = characters.AddRange(deserializedObject);

                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred {ex.Message}");
            }
            return characters;
        }

    }
}