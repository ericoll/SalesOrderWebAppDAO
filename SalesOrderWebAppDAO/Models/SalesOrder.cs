using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SalesOrderWebAppDAO.Models
{
    public class SalesOrder
    {
        
        [Display(Name = "Customer's Full Name")]
        [Required(ErrorMessage ="Please enter customer's full name." )]
        public string Customer { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please select a product.")]
        public string Product { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Please enter an amount.")]
        public decimal Price { get; set; }



        public SalesOrder()
        {

        }
    }

    public enum Products
    {
        Laptop,
        Keyboard,
        Paper
    }
}
