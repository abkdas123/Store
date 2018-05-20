using EF_DBContext.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EF_DBContext
{
    public class StoreContext : DbContext
    {
        public StoreContext()
            : base("name=StoreContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<MstStore> MstStore { get; set; }
        public virtual DbSet<MstUser> MstUser { get; set; }
        public virtual DbSet<MstCity> MstCity { get; set; }
        public virtual DbSet<MstArea> MstArea { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<MstStoreType> MstStoreType { get; set; }
        public virtual DbSet<MstCategory> MstCategory { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
    }
}
