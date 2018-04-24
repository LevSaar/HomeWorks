using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekzam
{
    public class Schedule:Entity
    {
        public DateTime LessonTimeStart { get; set; }
        public DateTime LessonTimeEnd { get; set; }
        public Subject GetSubject { get; set; }
        public Group GetGroup { get; set; }
        public Teacher GetTeacher { get; set; }
    }
}
