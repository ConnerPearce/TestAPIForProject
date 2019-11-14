using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestAPIForProject.Models
{
    public partial class TestAPIForProject20191024081403_dbContext : DbContext
    {
        public TestAPIForProject20191024081403_dbContext()
        {
        }

        public TestAPIForProject20191024081403_dbContext(DbContextOptions<TestAPIForProject20191024081403_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Test2> Test2 { get; set; }
        public virtual DbSet<TestTable> TestTable { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=tcp:testapiforproject20191024081403dbserver.database.windows.net,1433;Initial Catalog=TestAPIForProject20191024081403_db;Persist Security Info=False;User ID=Comp7211GroupProject;Password=Google1#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test2>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<TestTable>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fname)
                    .HasColumnName("FName")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .HasColumnName("LName")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
