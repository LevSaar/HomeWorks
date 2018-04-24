using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekzam
{
    public class Teacher:Entity
    {
        public string Name { get; set; }
        public int Experience { get; set; }
        public string Rank { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
