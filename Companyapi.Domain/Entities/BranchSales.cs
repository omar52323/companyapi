using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companyapi.Domain.Entities
{
    public class BranchSales
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float TotalSales { get; set; }
        public List<Sale> Sales { get; set; }
    }

    public class Sale
    {
        public string Date { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public float Amount { get; set; }
    }

    public class SalesFilter
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public string Id_GUID { get; set; }
    }

}
