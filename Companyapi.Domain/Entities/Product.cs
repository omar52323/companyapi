using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companyapi.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Status { get; set; }
        public List<Brand> StatusBrands { get; set; }
        public string Id_GUID { get; set; }
    }

    public class ProductByBrand
    {
        public int Id_Product { get; set; }
        public int Id_Brand { get; set; }
        public int Status { get; set; }
        public string Id_GUID { get; set; }

    }
}
