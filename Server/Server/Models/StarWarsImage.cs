namespace Server.Models
{
    public class StarWarsImage
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class AkababStarWarsResponse
    {
        public List<StarWarsChar> Results { get; set; }
    }

    public class StarWarsChar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Height { get; set; }
        public double Mass { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        public string Species { get; set; }
        public string Wiki { get; set; }
        public string Manufacturer { get; set; }
        public string ProductLine { get; set; }
        public string Model { get; set; }
        public string Class { get; set; }
        public string SensorColor { get; set; }
        public string PlatingColor { get; set; }
        public List<string> Equipment { get; set; }
    }

}
