using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
   public class DataContext : DbContext
    {
        public DataContext() : base("InterestRatesContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Agreement> Agreements { get; set; }



    }
}
 