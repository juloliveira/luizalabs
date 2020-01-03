using Luizalabs.Challenge.Contracts.v1.Requests;
using Luizalabs.Challenge.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Luizalabs.Challenge.Services.Products
{
    public interface IProductInsertService
    {
        Task<Product> Insert(ProductPost productPost);
    }
}
