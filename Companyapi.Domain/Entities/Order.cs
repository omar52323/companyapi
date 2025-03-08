using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companyapi.Domain.Entities
{
    public class Order
    {
        public int? Id { get; set; }
        public string BranchId { get; set; }
        public string? BranchName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public float Total { get; set; }
        public int Status { get; set; }
        public string Id_GUID { get; set; }
        public string? CreatedAt { get; set; }
        public string? FechaEntrega { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int? OrderId { get; set; }
        public string Id_GUID { get; set; }
        public string AditionalNotes { get; set; }
    }

  

}
