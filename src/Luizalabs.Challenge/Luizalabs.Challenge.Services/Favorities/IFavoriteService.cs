using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Luizalabs.Challenge.Contracts.v1.Requests;

namespace Luizalabs.Challenge.Services.Favorities
{
    public interface IFavoriteService
    {
        Task Include(long customerId, FavoritePut favoritePut);
    }
}
