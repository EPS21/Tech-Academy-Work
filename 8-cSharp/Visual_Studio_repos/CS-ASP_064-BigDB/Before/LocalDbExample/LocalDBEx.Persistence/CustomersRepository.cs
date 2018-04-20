using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalDBExample;

namespace LocalDBEx.Persistence
{
    public class CustomersRepository
    {
        public static List<LocalDBExample.DTO.Customer> GetCustomers()
        {
            ACMEEntities db = new ACMEEntities();
            var dbCustomers = db.Customers.OrderBy(p => p.Name).ToList();

            var dtoCustomers = new List<LocalDBExample.DTO.Customer>();

            foreach (var dbCustomer in dbCustomers)
            {
                var dtoCustomer = new LocalDBExample.DTO.Customer();

                dtoCustomer.CustomerId = dbCustomer.CustomerID;
                dtoCustomer.Name = dbCustomer.Name;
                dtoCustomer.Address = dbCustomer.Address;
                dtoCustomer.City = dbCustomer.City;
                dtoCustomer.State = dbCustomer.State;
                dtoCustomer.PostalCode = dbCustomer.PostalCode;
                dtoCustomer.Notes = dbCustomer.Notes;

                dtoCustomers.Add(dtoCustomer);
            }

            return dtoCustomers;
        }

        public static void AddCustomer(LocalDBExample.DTO.Customer newCustomer)
        {
            ACMEEntities db = new ACMEEntities();
            var dbCustomers = db.Customers;

            var customer = new Customer();

            // checking if
            if (newCustomer.Name.Trim().Length == 0)
                throw new Exception("Name is a required field");

            // other validation here.

            customer.CustomerID = newCustomer.CustomerId;
            customer.Name = newCustomer.Name;
            customer.Address = newCustomer.Address;
            customer.City = newCustomer.City;
            customer.State = newCustomer.State;
            customer.PostalCode = newCustomer.PostalCode;
            customer.Notes = newCustomer.Notes;

            try
            {
                dbCustomers.Add(customer);
                // won't actually save to database unless you call SaveChanges()
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the exception

                throw ex;
            }
            
        }

    }
}
