using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankAccount
    {
        [Key]
        public int Id { get; set; }
        public int CreditNumber { get; set; }
        public double Money { get; set; }
    }
}
