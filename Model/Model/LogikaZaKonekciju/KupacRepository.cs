using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class KupacDb : DbContext
    {
        public DbSet<Kupac> Kupac { get; set; }
    }
    public class KupacRepository : SqlRepository<Kupac>
    {
        public KupacRepository(DbContext context) : base(context)
        {
        }
    }
}
