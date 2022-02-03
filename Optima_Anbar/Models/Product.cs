using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Optima_Anbar.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public double Quantity { get; set; }

        public double SalePrice { get; set; }

        public double BuyingPrice { get; set; }

        public DateTime AddingDate { get; set; }

        public double Profit { get; set; }
    }
}
