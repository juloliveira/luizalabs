using Luizalabs.Challenge.Contracts.v1.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Luizalabs.Challenge.Services.Products
{
    public interface IProductPagination
    {
        Task<Pagination> Page(int page, int size);
    }
}
