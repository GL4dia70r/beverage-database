using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace cis237_assignment_5.Models
{
    public partial class BeverageContext : DbContext
    {
        public BeverageContext()
        {

        }

        public BeverageContext(DbContextOptions<BeverageContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Beverage> Beverages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=barnesbrothers.ddns.net;Database=BeverageDAllen;User Id=dallen;Password=password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beverage>(entity =>
            {
                entity.Property(e => e.Name).IsFixedLength();

                entity.Property(e => e.Pack).IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
