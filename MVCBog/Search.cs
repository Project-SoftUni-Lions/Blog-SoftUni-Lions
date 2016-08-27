namespace MVCBog
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Search : DbContext
    {
        public Search()
            : base("name=Search")
        {
        }

        public virtual DbSet<Ad> Ads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
