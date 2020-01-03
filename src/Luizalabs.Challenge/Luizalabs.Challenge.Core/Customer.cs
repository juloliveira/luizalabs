using System;
using System.Collections.Generic;
using System.Text;

namespace Luizalabs.Challenge.Core
{
    public class Customer : Entity
    {
        private IEnumerable<Product> _favoritiesProducts;

        public Customer() : base()
        {
            _favoritiesProducts = new List<Product>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public IEnumerable<Product> FavoritiesProducts => _favoritiesProducts;

        public void SetFavoritiesProducts(IEnumerable<Product> favorities)
        {
            _favoritiesProducts = favorities;
        }
    }
}
