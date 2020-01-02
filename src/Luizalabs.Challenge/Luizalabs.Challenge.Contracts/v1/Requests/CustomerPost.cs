using Luizalabs.Challenge.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luizalabs.Challenge.Contracts.v1.Requests
{
    public class CustomerPost
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Customer CreateDomain()
        {
            return new Customer
            {
                Name = this.Name,
                Address = this.Address,
                Email = this.Email
            };
        }
    }
}
