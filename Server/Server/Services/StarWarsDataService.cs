using Server.Interfaces;
using Server.Models;
using System.Collections.Immutable;

namespace Server.Services
{
    public class StarWarsDataService : IStarWarsDataService
    {
        public ImmutableList<StarWarsCharacter> StarWarsData { get; set; }
    }
}
