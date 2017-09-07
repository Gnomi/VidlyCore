using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VidlyCore.Models;
using VidlyCore.Data;
using System.Net.Http;
using System.Net;
using VidlyCore.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;


namespace VidlyCore.Controllers.Api
{
    //    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        //create a field to store the mapper object
        //private readonly IMapper _mapper;

        private ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
          
        }
 
        // GET /api/customers
        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return  _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        // GET /api/customers/1
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
                //              throw new HttpResponseException();    
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
//            return new ObjectResult(Mapper.Map<Customer, CustomerDto>(customer)); 
//            return new ObjectResult(customer);
        }



        //POST /api/customers
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(this.Request.GetDisplayUrl() + "/" + customer.Id), customerDto);
                // Ok(customerDto);
            //            return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);

        }

        // PUT /api/customers/i
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);
            //customerInDb.Name = customer.Name;
            //customerInDb.Birthdate = customer.Birthdate;
            //customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}