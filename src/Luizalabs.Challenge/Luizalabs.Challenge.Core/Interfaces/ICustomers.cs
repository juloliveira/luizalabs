using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Luizalabs.Challenge.Core.Interfaces
{
    public interface ICustomers
    {
        Task<IEnumerable<Customer>> GetAllPerPage(int page);
        Task<Customer> GetById(long id);
        Task Insert(Customer customer);
        Task Update(Customer customer);
        Task RemoveById(long id);

        Task<bool> ExistsEmail(string email);
    }
}
