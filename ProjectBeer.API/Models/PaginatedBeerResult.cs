using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBeer.API.Models
{
    public class PaginatedBeerResult
    {
        public int CurrentPage { get; set; }
        public int NumberOfPages { get; set; }
        public int TotalResults { get; set; }
        public IEnumerable<Beer> Data { get; set; }
        public string status { get; set; }
    }
}