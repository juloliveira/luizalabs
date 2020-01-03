using Luizalabs.Challenge.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luizalabs.Challenge.Contracts.v1.Requests
{
    public class ReviewPut
    {
        public long CustomerId { get; set; }
        public double Score { get; set; }
        public string Comment { get; set; }

        public Review CreateDomain(Customer customer)
        {
            return new Review(customer, this.Score, this.Comment);
        }
    }
}
