using System;
using System.Collections.Generic;
using System.Text;

namespace Luizalabs.Challenge.Core
{
    public class Customer : Entity
    {
        private IList<Product> _favoriteProducts;

        public Customer() : base()
        {
            _favoriteProducts = new List<Product>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public IEnumerable<Product> FavoriteProducts => _favoriteProducts;

        public void AddProductFavorite(Product product)
        {
            if (product == null) throw new ArgumentException();

            _favoriteProducts.Add(product);
        }
    }
}
