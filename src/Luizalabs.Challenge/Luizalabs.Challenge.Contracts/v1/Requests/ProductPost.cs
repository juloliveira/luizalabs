using Luizalabs.Challenge.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luizalabs.Challenge.Contracts.v1.Requests
{
    public class ProductPost
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public long BrandId { get; set; }

        public Product CreateDomain(Brand brand)
        {
            return new Product
            {
                Title = this.Title,
                Price = this.Price,
                Image = this.Image,
                Brand = brand
            };
        }
    }
}
