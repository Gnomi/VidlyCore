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
            

    //        IQueryable<Customer> c = _context.Customers
    //.Include(cus => cus.MembershipType)
    //    .ThenInclude(d => d.DiscountRate);
        



            //foreach (Customer c in customers)
            //{
            //    _context.Entry(c).Collection(d => d.MembershipType)
            //        .Query().Where( e => e.MembershipTypeId = )
            //}
            //              .Include(c => c.MembershipType).Load();
            //  .ThenInclude(m => m.DiscountRate)
            //              .ToList();
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

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