using CheckoutSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.DTO
{
    public class OrderRequest
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public double DrinksDiscount { get; set; }
        public double ServiceChargeOnFood { get; set; }
        public DateTime DiscountHours { get; set; }

    }

    public class OrderResponse
    {
        public string? TotalBill { get; set; }
    }
}
