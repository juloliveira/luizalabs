using System;
using System.Collections.Generic;
using System.Linq;

namespace Luizalabs.Challenge.Contracts.v1.Responses
{
    public class Pagination
    {
        public Pagination(IEnumerable<Core.Product> products, int page, int size, int total)
        {
            CurrentPage = page;
            Size = size;
            Registers = total;

            Pages = (total / size) + 1;

            Products = products.Select(x => new Pagination.Product
            { 
                Id = x.Id,
                Title = x.Title,
                Image = x.Image,
                Price = x.Price,
                Score = x.ReviewScore,
                Brand = x.Brand.Name
            });
        }

        public IEnumerable<Pagination.Product> Products { get; set; }
        public int CurrentPage { get; set; }
        public int Size { get; set; }
        public int Pages { get; set; }
        public int Registers { get; set; }

        public class Product
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Image { get; set; }
            public double Price { get; set; }
            public double Score { get; set; }
            public string Brand { get; set; }
        }
    }
}
