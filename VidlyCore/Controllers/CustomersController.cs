using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VidlyCore.Models;
using VidlyCore.Data;
using Microsoft.EntityFrameworkCore;

namespace VidlyCore.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        //ctor for shortcut
        public CustomersController( ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            //base.Dispose(disposing);
        }


        public IActionResult Index()
        {
            //var customers = _context.Customers;

            var customers = _context.Customers
                .Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(m=>m.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);

        }

        private IEnumerable<Customer> GetCustomers()
        {
             return new List<Customer>
             {
                 new Customer { Id = 1, Name = "John Smith" },
                 new Customer { Id = 2, Name = "Mary Williams" }
             };
        }
     }

}