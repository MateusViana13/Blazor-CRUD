using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_WEBAPI_BLAZOR.Shared
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public string Engine { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int Year { get; set; }      
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
    }
}
