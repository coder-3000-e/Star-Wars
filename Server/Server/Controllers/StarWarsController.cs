using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;
using Server.Helpers;
using Server.Interfaces;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarWarsController : ControllerBase
    {
        private readonly ILogger<StarWarsController> _logger;
        private readonly IStarWars _starWarsService;
        private readonly IStarWarsImage _starWarsImageService;
        private readonly IStarWarsDataService _starWarsDataService;

        public StarWarsController(ILogger<StarWarsController> logger,
            IStarWars starWarsService,
            IStarWarsImage starWarsImageService,
            IStarWarsDataService starWarsDataService)
        {
            _logger = logger;
            _starWarsService = starWarsService;
            _starWarsImageService = starWarsImageService;
            _starWarsDataService = starWarsDataService;
        }

        [HttpGet(Name = "GetAllStarWarsPeopleNames")]
        public async Task<IActionResult> GetAsync()
        {
            var starWarsResult = await _starWarsService.GetStarWarsPeopleNamesAsync();
            var starsWarsImages = await _starWarsImageService.GetStarWarsPeopleNamesWithImagesAsync();

            _starWarsDataService.StarWarsData = starWarsResult.Select(x => new StarWarsCharacter
            {
                Name = x.Name,
                Height = x.Height,
                Mass = x.Mass,
                HairColor = x.HairColor,
                SkinColor = x.SkinColor,
                EyeColor = x.EyeColor,
                BirthYear = x.BirthYear,
                Gender = x.Gender,
                Homeworld = x.Homeworld,
                Films = x.Films,
                Species = x.Species,
                Vehicles = x.Vehicles,
                Starships = x.Starships,
                Created = x.Created,
                Edited = x.Edited,
                Url = x.Url,
                Image = starsWarsImages.FirstOrDefault(a => a.Name == x.Name)?.Image
            }).ToImmutableList();

            return Ok(_starWarsDataService.StarWarsData);
        }

        [HttpGet("CompareCharacters")]
        public IActionResult CompareCharacters([FromQuery] string firstCharacter, [FromQuery] string secondCharacter)
        {
            var starWarsData = _starWarsDataService.StarWarsData;
            var character1 = starWarsData.FirstOrDefault(c => c.Name == firstCharacter);
            var character2 = starWarsData.FirstOrDefault(c => c.Name == secondCharacter);

            if (character1 == null || character2 == null)
            {
                return BadRequest("Character not found");
            }
            var comparison = new CompareAttributes();
            var attributeComparisons = new Dictionary<string, string>();
            attributeComparisons["Name"] = comparison.CompareStringAttributes(character1.Name, character2.Name, character1.Name, character2.Name);

            attributeComparisons["Height"] = comparison.CompareDoubleAttributes(character1.Name, character2.Name, character1.Height, character2.Height, "height");
            attributeComparisons["Mass"] = comparison.CompareDoubleAttributes(character1.Name, character2.Name, character1.Mass, character2.Mass, "mass");

            attributeComparisons["Vehicles"] = comparison.CompareCountAttributes(character1.Name, character2.Name, character1.Vehicles, character2.Vehicles, "vehicles");
            attributeComparisons["Starships"] = comparison.CompareCountAttributes(character1.Name, character2.Name, character1.Starships, character2.Starships, "starships");
            attributeComparisons["Films"] = comparison.CompareCountAttributes(character1.Name, character2.Name, character1.Films, character2.Films, "films");

            attributeComparisons["HairColor"] = comparison.CompareStringAttributes(character1.Name, character2.Name, character1.HairColor, character2.HairColor);
            attributeComparisons["SkinColor"] = comparison.CompareStringAttributes(character1.Name, character2.Name, character1.SkinColor, character2.SkinColor);
            attributeComparisons["EyeColor"] = comparison.CompareStringAttributes(character1.Name, character2.Name, character1.EyeColor, character2.EyeColor);
            attributeComparisons["BirthYear"] = comparison.CompareStringAttributes(character1.Name, character2.Name, character1.BirthYear, character2.BirthYear);
            attributeComparisons["Gender"] = comparison.CompareStringAttributes(character1.Name, character2.Name, character1.Gender, character2.Gender);

            return Ok(attributeComparisons);
        }
    }
}
