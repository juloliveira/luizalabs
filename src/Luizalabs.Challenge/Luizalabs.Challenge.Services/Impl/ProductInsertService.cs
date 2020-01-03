using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Luizalabs.Challenge.Contracts.v1.Requests;
using Luizalabs.Challenge.Core;
using Luizalabs.Challenge.Core.Interfaces;
using Luizalabs.Challenge.Services.Products;

namespace Luizalabs.Challenge.Services.Impl
{
    public class ProductInsertService : IProductInsertService
    {
        private IBrands _brands;
        private IProducts _products;

        public ProductInsertService(IBrands brands, IProducts products)
        {
            _brands = brands;
            _products = products;
        }
        public async Task<Product> Insert(ProductPost productPost)
        {
            var brand = await _brands.GetById(productPost.BrandId);

            if (brand == null) throw new Exception("FABRICANTE não encontrado.");

            var product = productPost.CreateDomain(brand);

            await _products.Insert(product);

            return product;
        }
    }
}
