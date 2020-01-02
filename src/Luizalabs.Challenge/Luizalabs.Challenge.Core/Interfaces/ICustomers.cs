using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Luizalabs.Challenge.Core.Interfaces
{
    public interface ICustomers
    {
        Task<IEnumerable<Customer>> GetAllPerPage(int page);
        Task<bool> ExistsEmail(string email);
        Task<bool> Insert(Customer customer);
        Task<Customer> GetById(long id);
        Task Update(Customer customer);
    }
}
