using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new GruppaCreatorContext())
            {
                context.Groups.Add(new Gruppa { Name = "MyGroup" });
                context.SaveChanges();
            }
        }
    }
}
