using Luizalabs.Challenge.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Luizalabs.Challenge.Tests.Core
{
    public class CustomerTests
    {
        Customer _customer;

        [SetUp]
        public void Setup()
        {
            _customer = new Customer();
        }

        [Test]
        public void On_Create()
        {
            Assert.AreEqual(0, _customer.FavoritiesProducts.Count());
        }

        [Test]
        public void Can_Add_Product_Favorite()
        {
            var product = new Product();

            _customer.AddProductFavorite(product);

            Assert.AreEqual(1, _customer.FavoritiesProducts.Count());
        }
    }
}
