using System;
using System.Collections.Generic;
using System.Text;

namespace Luizalabs.Challenge.Core
{
    public class Review : Entity
    {
        protected Review() : base() { }

        public Review(Customer customer, double score, string comment)
        {
            Customer = customer;
            Score = score;
            Comment = comment;
        }

        public Customer Customer { get; protected set; }
        public double Score { get; protected set; }
        public string Comment { get; protected set; }
    }
}
