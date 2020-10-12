using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
   public class Agreement
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }

        public string BaseRateCode { get; set; }

        public decimal Margin { get; set; }

        public int AgreementDuration { get; set; }

    }
}
