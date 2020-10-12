using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class AgreementDTO
    {
        public int Amount { get; set; }

        public string BaseRateCode { get; set; }

        public decimal Margin { get; set; }

        public int AgreementDuration { get; set; }

    }
}
