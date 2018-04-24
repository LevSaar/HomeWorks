using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekzam
{
    public class Group : Entity
    {
        public string Name { get; set; }
        public DateTime StudyYear { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
