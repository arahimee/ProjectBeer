namespace ProjectBeer.API.Models
{
    public class Beer
    {
        public string Id { get; set; }
        public string NameDisplay { get; set; }
        public string Description { get; set; }
        public string ABV { get; set; }
        public string StatusDisplay { get; set; }
        public string Status { get; set; }
        public string IsOrganic { get; set; }
        public string ServingTemperature { get; set; }
        public string ServingTemperatureDisplay { get; set; }
        public string UpdateDate { get; set; }
        public BeerLabel Labels { get; set; }
        public BeerStyle Style { get; set; }
        public BeerGlass Glass { get; set; }
    }
}