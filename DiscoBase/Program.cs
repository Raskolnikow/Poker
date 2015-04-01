using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DiscoBase
{
    class Program
    {
       

        static void Main(string[] args)
        {
            DiscoDAO dao = new DiscoDAO();

            List<Customer> customerList = dao.GetCustomerList();

            foreach(Customer c in customerList)
            {
                Console.WriteLine(c.Name + ", " + c.Vorname);
            }
        }
    }
}
