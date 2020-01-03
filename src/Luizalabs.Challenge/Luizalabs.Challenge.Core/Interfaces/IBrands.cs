using System.Threading.Tasks;

namespace Luizalabs.Challenge.Core.Interfaces
{
    public interface IBrands
    {
        Task Insert(Brand brand);
        Task<Brand> GetById(long brandId);
    }
}
