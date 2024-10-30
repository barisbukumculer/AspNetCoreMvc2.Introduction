using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCoreMvc2.Introduction.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public List<Customer> Get()
        {
            return new List<Customer>
            {
                new Customer {Id=1,FirstName="Barış",LastName="Bükümcüler"},
                new Customer {Id=2,FirstName="John",LastName="Wayne"},
                new Customer {Id=3,FirstName="Onur",LastName="Bükümcüler"}

            };
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
