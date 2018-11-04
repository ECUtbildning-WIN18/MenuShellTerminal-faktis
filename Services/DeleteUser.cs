using Domain;
using Domain.Contexts;
using System.Data.SqlClient;

namespace Services
{
    public class DeleteUser
    {
        public void Delete(string userName)
        {
            using (var db = new MenuShellContext())
            {
                var customer = GetCustomerWithUserName(userName);
                if (customer!=null)
                {
                   
                    db.Customer.Remove(customer);
                    db.SaveChanges();
                    return;
                }
                var admin = GetAdminWithUserName(userName);
                if (admin != null)
                {

                    db.Admin.Remove(admin);
                    db.SaveChanges();
                    return;
                }


            }
        }
        private static SystemAdministrator GetAdminWithUserName(string username)
        {
            using (var context = new MenuShellContext())
            {
                
                foreach (var admin in context.Admin)
                {
                    if (admin.UserName == username) return admin;
                }
            }
            return null;
        }

        private static Customer GetCustomerWithUserName(string username)
        {
            using (var context = new MenuShellContext())
            {

                foreach (var customer in context.Customer)
                {
                    if (customer.UserName == username) return customer;
                }
            }
            return null;
        }
    }
}
