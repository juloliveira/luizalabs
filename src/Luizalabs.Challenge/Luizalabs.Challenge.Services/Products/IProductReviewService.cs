using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Luizalabs.Challenge.Contracts.v1.Requests;
using Luizalabs.Challenge.Core;

namespace Luizalabs.Challenge.Services.Products
{
    public interface IProductReviewService
    {
        Task<Review> Insert(long productId, ReviewPut reviewPut);
    }
}
