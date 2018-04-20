namespace HomeWork3
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GruppaCreatorContext : DbContext
    {
        public GruppaCreatorContext()
            : base("name=GruppaCreatorContext")
        {
        }

        public DbSet<Gruppa> Groups { get; set; }
    }
}
