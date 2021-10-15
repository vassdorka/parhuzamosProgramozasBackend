using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CarBrandId { get; set; }
        public CarBrands CarBrand { get; set; }
    }
}
