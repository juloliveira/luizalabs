using System;
using Luizalabs.Challenge.Core;

namespace Luizalabs.Challenge.Contracts.v1.Requests
{
    public class CustomerPut
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public void UpdateDomain(Customer customer)
        {
            customer.Name = Name;
            customer.Address = Address;
        }
    }
}
