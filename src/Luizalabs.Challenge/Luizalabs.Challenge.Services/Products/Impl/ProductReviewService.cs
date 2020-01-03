using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Luizalabs.Challenge.Contracts.v1.Requests;
using Luizalabs.Challenge.Core;
using Luizalabs.Challenge.Core.Interfaces;
using Luizalabs.Challenge.Services.Products;

namespace Luizalabs.Challenge.Services.Products.Impl
{
    public class ProductReviewService : IProductReviewService
    {
        private IProducts _products;
        private ICustomers _customers;

        public ProductReviewService(IProducts products, ICustomers customers)
        {
            _products = products;
            _customers = customers;
        }
        public async Task<Review> Insert(long productId, ReviewPut reviewPut)
        {
            Product product = await _products.GetById(productId);

            if (product == null) throw new Exception("PRODUTO não encontrado");

            Customer customer = await _customers.GetById(reviewPut.CustomerId);

            if (customer == null) throw new Exception("CLIENTE não encontrado");

            var review = reviewPut.CreateDomain(customer);
            await _products.InsertReview(product, review);

            return review;
        }
    }
}
