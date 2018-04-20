using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalDBExample;
using LocalDBEx.Persistence;

namespace LocalDBExample.Domain
{
    public class CustomerManager
    {
        public static List<DTO.Customer> GetCustomers()
        {
            var customers = CustomersRepository.GetCustomers();
            return customers;
        }

        public static void AddCustomer(LocalDBExample.DTO.Customer customer)
        {
            try
            {
                CustomersRepository.AddCustomer(customer);
            }
            catch (Exception)
            {
                // Log it or do w/e
                throw;
            }
            
        }

    }
}
