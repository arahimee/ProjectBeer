using System;

namespace ProjectBeer.API.Models
{
    public class BeerStyle
    {
        public BeerStyleCategory Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AbvMin { get; set; }
        public string AbvMax { get; set; }
        public string UpdateDate { get; set; }
    }
}