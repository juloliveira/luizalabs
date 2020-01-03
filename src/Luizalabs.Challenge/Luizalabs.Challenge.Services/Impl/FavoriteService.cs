using Luizalabs.Challenge.Contracts.v1.Requests;
using Luizalabs.Challenge.Core.Interfaces;
using Luizalabs.Challenge.Services.Favorities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Luizalabs.Challenge.Services.Impl
{
    public class FavoriteService : IFavoriteService
    {
        private ICustomers _customers;
        private IProducts _products;

        public FavoriteService(ICustomers customers, IProducts products)
        {
            _customers = customers;
            _products = products;
        }

        public async Task Include(long customerId, FavoritePut favoritePut)
        {
            var customer = await _customers.GetById(customerId);

            if (customer == null) throw new Exception("CLIENTE não encontrado.");

            var product = await _products.GetById(favoritePut.ProductId);

            if (customer.FavoritiesProducts.Any(x => x.Id == favoritePut.ProductId))
                throw new Exception("PRODUTO já cadastrado como favorito.");

            await _customers.IncludeFavorite(customer, product);

        }
    }
}
