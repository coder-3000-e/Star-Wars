using System.Collections.Immutable;
using Server.Models;

namespace Server.Interfaces
{
    public interface IStarWars
    {
        Task<ImmutableList<Character>> GetStarWarsPeopleNamesAsync();
    }
}
