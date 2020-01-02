using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Luizalabs.Challenge.Core;
using Moq;
using NUnit.Framework;

namespace Luizalabs.Challenge.Tests.Core
{
    public class ProductTests
    {
        Product _product;

        [SetUp]
        public void Setup()
        {
            _product = new Product();
        }

        [Test]
        public void Can_Add_Review()
        {
            var customer = new Customer();
            var review = new Review(customer, 3.2, "Comment Review");

            _product.AddReview(review);

            Assert.AreEqual(1, _product.Reviews.Count());
            Assert.AreEqual(3.2, _product.ReviewScore);
        }

        [Test]
        public void Should_Compute_Score_Average()
        {
            var customer = new Customer();

            _product.AddReview(new Review(customer, 3.3, "Comment Review"));
            _product.AddReview(new Review(customer, 2.8, "Comment Review"));
            _product.AddReview(new Review(customer, 1.9, "Comment Review"));
            _product.AddReview(new Review(customer, 4.5, "Comment Review"));

            Assert.AreEqual(4, _product.Reviews.Count());
            Assert.AreEqual(3.125, _product.ReviewScore);
        }

    }
}
