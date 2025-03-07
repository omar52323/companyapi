using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companyapi.Domain.Entities
{
    public class Brand
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Status { get; set; }
        public string? Id_GUID { get; set; }
        public float?  TotalVentas { get; set; }
        
    }
}
