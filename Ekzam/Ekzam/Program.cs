using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekzam
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new DataModel())
            {
                var schedule1 = new Schedule { LessonTimeStart = new DateTime(2018, 4, 1), LessonTimeEnd = new DateTime(2018, 4, 29) };
                var subject1 = new Subject { Name = "Math" };
                var group1 = new Group { Name = "C001", StudyYear = new DateTime(2018, 1, 1) };
                var student1 = new Student { Name = "Anton", AverageScore = 3.8 };
                var teacher1 = new Teacher { Name = "Pavel Sidorov", Experience = 20, Rank = "Master" };

                connection.Schedules.Add(schedule1);
                connection.Subjects.Add(subject1);
                connection.Groups.Add(group1);
                connection.Students.Add(student1);
                connection.Teachers.Add(teacher1);

                connection.SaveChanges();
            }
        }
    }
}
