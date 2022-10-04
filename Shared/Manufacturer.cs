using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_WEBAPI_BLAZOR.Shared
{
    public class Manufacturer
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
