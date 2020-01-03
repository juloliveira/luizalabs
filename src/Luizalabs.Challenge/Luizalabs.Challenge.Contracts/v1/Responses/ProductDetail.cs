using System;
using System.Collections.Generic;
using System.Text;

namespace Luizalabs.Challenge.Contracts.v1.Responses
{
    public class ProductDetail
    {
        public ProductDetail()
        {
            Reviews = new List<ProductReview>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public double Score { get; set; }
        public string Brand { get; set; }

        public List<ProductReview> Reviews { get; set; }
    }

    public class ProductReview
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public double Score { get; set; }
        public string Comment { get; set; }

    }
}
