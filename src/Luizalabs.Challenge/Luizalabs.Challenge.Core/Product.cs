using System;
using System.Collections.Generic;
using System.Linq;

namespace Luizalabs.Challenge.Core
{
    public class Product : Entity
    {
        private IList<Review> _reviews;

        public Product() : base()
        {
            _reviews = new List<Review>();
        }

        public string Title { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public Brand Brand { get; set; }

        public IEnumerable<Review> Reviews => _reviews;
        public double ReviewScore { get; protected set; }

        public void AddReview(Review review)
        {
            _reviews.Add(review);
        }
    }
}
