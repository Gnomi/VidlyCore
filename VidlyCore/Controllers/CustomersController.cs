using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VidlyCore.Models;
using VidlyCore.Data;
using Microsoft.EntityFrameworkCore;
using VidlyCore.Models.CustomerViewModels;

namespace VidlyCore.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        //ctor for shortcut
        public CustomersController(ApplicationDbContext context)
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


        public IActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                //customerID will initialize to 0
                Customer = new Customer(),
                MembershipTypes = membershipType
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
                //add to memory
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //update all properties of this object, open up security holes 
                //TryUpdateModelAsync(customerInDb);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

//            return View("Index");
            return RedirectToAction("Index", "Customers");
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers
               .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
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