using Server.Models;
using System.Collections.Immutable;

namespace Server.Interfaces
{
    public interface IStarWarsDataService
    {
        ImmutableList<StarWarsCharacter> StarWarsData { get; set; }
    }
}
