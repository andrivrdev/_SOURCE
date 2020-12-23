using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Models
{
    public interface ICustomerSoapService
    {
        Task<List<ICustomer>> GetAllCustomers(string criteria = null);
    }
}
