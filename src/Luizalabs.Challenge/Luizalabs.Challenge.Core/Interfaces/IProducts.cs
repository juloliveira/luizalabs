using System.Threading.Tasks;

namespace Luizalabs.Challenge.Core.Interfaces
{
    public interface IProducts
    {
        Task Insert(Product poduct);
    }
}
