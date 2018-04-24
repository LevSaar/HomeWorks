using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekzam
{
    public class Student : Entity
    {
        public string Name { get; set; }
        public double AverageScore { get; set; }
        public Group GetGroup { get; set; }
    }
}
