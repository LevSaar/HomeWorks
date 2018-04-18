using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    public class Gruppa
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
