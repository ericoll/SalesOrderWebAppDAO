using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesOrderWebAppDAO.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SalesOrderWebAppDAO.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllSalesOrders()
        {
            List <SalesOrderModel>  solist  = new SalesOrderModelServices().GetSalesOrders();
            return View(solist);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SalesOrder()
        {
            return View();
        }

        public IActionResult SalesOrderDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            SalesOrderModel solist = new SalesOrderModelServices().GetSalesOrderById((int)id);
            
            if (solist == null)
            {
                return NotFound();
            }

            return View(solist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult SalesOrder([Bind("Customer,Product,Price")] SalesOrderModel salesOrder)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(salesOrder);
                //await _context.SaveChangesAsync();
                new SalesOrderModelServices().SaveNeSalesOrder(salesOrder);
                return RedirectToAction(nameof(AllSalesOrders));
            }
            return View(salesOrder);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
