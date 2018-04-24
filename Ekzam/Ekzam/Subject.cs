using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekzam
{
    public class Subject:Entity
    {
        public string Name { get; set; }
        public ICollection<Teacher> GetTeacher { get; set; }
    }
}
