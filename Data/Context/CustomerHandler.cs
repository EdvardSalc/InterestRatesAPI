using Data.DTO;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class CustomerHandler
    {
        private DataContext db = new DataContext();

        public CustomerDTO GetCustomerByAgreementId(int agrId)
        {
            CustomerDTO customer = db.Customers.Where(c => c.Agreements.Any(a => a.Id == agrId))
                .Select(s => new CustomerDTO { PersonalId = s.PersonalId, Name = s.Name }).FirstOrDefault();

            return customer;
        }
    }
}
