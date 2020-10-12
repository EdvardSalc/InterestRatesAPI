namespace Data.Migrations
{
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Context.DataContext>
    {
        //public Configuration()
        //{
        //    AutomaticMigrationsEnabled = false;
        //}

        protected override void Seed(Data.Context.DataContext context)
        {
            if (!context.Agreements.Any())
            {

                List<Agreement> agreementsGoras = new List<Agreement> { new Agreement() { Amount = 12000, BaseRateCode = "VILIBOR3m", Margin = 1.6m, AgreementDuration = 60 } };


                List<Agreement> agreementsDange = new List<Agreement> {
                new Agreement() { Amount = 8000, BaseRateCode = "VILIBOR1y", Margin = 2.2m, AgreementDuration = 36 },
                new Agreement() { Amount = 10000, BaseRateCode = "VILIBOR6m", Margin = 1.85m, AgreementDuration = 24 }
            };


                List<Customer> customers = new List<Customer> {
                 new Customer() { Name = "Goras Trusevičius", PersonalId = 67812203006, Agreements = agreementsGoras },
                 new Customer() { Name = "Dange Kulkavičiutė", PersonalId = 78706151287, Agreements = agreementsDange },
            };


                customers.ForEach(c => context.Customers.Add(c));
                context.SaveChanges();

            }
        }
    }
}
