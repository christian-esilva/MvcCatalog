using MvcCatalog.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCatalog.Data.Contexts
{
    public class MvcCatalogDataContext : DbContext
    {
        public MvcCatalogDataContext()
            :base("MvcCatalogConnectionString")
        { }

        public DbSet<User> Users { get; set; }
    }
}
