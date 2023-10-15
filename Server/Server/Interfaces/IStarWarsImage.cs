using System.Collections.Immutable;
using Server.Models;

namespace Server.Interfaces
{
    public interface IStarWarsImage
    {
        Task<ImmutableList<StarWarsImage>> GetStarWarsPeopleNamesWithImagesAsync();
    }
}
