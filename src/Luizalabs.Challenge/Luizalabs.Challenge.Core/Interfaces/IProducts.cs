using System.Threading.Tasks;

namespace Luizalabs.Challenge.Core.Interfaces
{
    public interface IProducts
    {
        Task Insert(Product poduct);
        Task<Product> GetById(long productId);
        Task InsertReview(Product product, Review review);
    }
}
