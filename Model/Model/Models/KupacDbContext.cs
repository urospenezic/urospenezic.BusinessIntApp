namespace Model
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

        public partial class KupciDbContext : DbContext
        {
            public KupciDbContext()
            {
            }
            public virtual DbSet<Kupac> Kupacs { get; set; }
        }
    }

