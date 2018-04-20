using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LocalDBExample;
using LocalDbExample;


namespace LocalDbExample
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            ACMEEntities1 db = new ACMEEntities1();

            var customers = db.Customers;

            string result = "";
            */

            /*
            foreach (var customer in customers)
            {
                result += "<p>" + customer.Name + "</p>";
            }
            */

            /*
            var customers = LocalDBExample.Domain.CustomerManager.GetCustomers();

            customersGridView.DataSource = customers.ToList();
            customersGridView.DataBind();
            */

            displayCustomers();

            //resultLabel.Text = result;
        }

        // this fucking bullshit doesn't work
        protected void okButton_Click(object sender, EventArgs e)
        {
            var newCustomer = new LocalDBExample.DTO.Customer();

            newCustomer.CustomerId = Guid.NewGuid();
            newCustomer.Name = nameTextBox.Text;
            newCustomer.Address = addressTextBox.Text;
            newCustomer.City = cityTextBox.Text;
            newCustomer.State = stateTextBox.Text;
            newCustomer.PostalCode = zipTextBox.Text;
            newCustomer.Notes = notesTextBox.Text;

            try
            {
                LocalDBExample.Domain.CustomerManager.AddCustomer(newCustomer);
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
            displayCustomers();
        }
        

        private void displayCustomers()
        {
            var customers = LocalDBExample.Domain.CustomerManager.GetCustomers();

            customersGridView.DataSource = customers.ToList();
            customersGridView.DataBind();
        }
    }
}