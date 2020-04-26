using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace myasp.Model
{
    public partial class NEWFarmerContext : DbContext
    {
        public NEWFarmerContext()
        {
        }

        public NEWFarmerContext(DbContextOptions<NEWFarmerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NewProducts> NewProducts { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Products1> Products1 { get; set; }
        public virtual DbSet<Products11> Products11 { get; set; }
        public virtual DbSet<Products2> Products2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:serveralexa.database.windows.net,1433;Initial Catalog=rahatu;Persist Security Info=False;User ID=alexa;Password=facemAZURE!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products1>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Link).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Price).IsUnicode(false);
            });

            modelBuilder.Entity<Products11>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Products2>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Link).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Price).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
