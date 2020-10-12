using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class RateResponse
    {
        public CustomerDTO customer { get; set; }

        public AgreementDTO agreement { get; set; }

        public decimal currentInterestRate { get; set; }

        public decimal newInterestRate{ get; set; }

        public decimal differenceBetweenRates { get; set; }

    }
}
