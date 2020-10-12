using Data.DTO;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class AgreementHandler
    {
        private DataContext db = new DataContext();

        public IEnumerable<Agreement> GetAgreements()
        {

                var agreements = from q in db.Agreements.AsEnumerable()
                           select new Agreement
                           {
                               Id = q.Id, 
                               AgreementDuration = q.AgreementDuration, 
                               BaseRateCode = q.BaseRateCode,
                               Amount = q.Amount, 
                               Margin = q.Margin
                           };
            return agreements;
        }

        public AgreementDTO GetAgreement(int Id)
        {
            DTO.AgreementDTO agreement = (from q in db.Agreements where q.Id == Id 
                             select new AgreementDTO()
                             {
                                 AgreementDuration = q.AgreementDuration,
                                 BaseRateCode = q.BaseRateCode,
                                 Amount = q.Amount,
                                 Margin = q.Margin
                             }).FirstOrDefault();

            return agreement;
        }

    }
}
