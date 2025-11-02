using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDbContext() : base()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in entries)
            {
                switch(item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreatedByID = "123456";
                        item.Entity.CreatedByName = "Added Fady";
                        item.Entity.CreatedDateTime = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        item.Entity.ModifiedByID = "654321";
                        item.Entity.ModifiedByName = "Modified Fady";
                        item.Entity.ModifiedDateTime = DateTime.UtcNow;
                        break;
                    case EntityState.Deleted:
                        item.State = EntityState.Modified;
                        item.Entity.IsArchived = true;
                        item.Entity.ArchivedByID = "000000";
                        item.Entity.ArchivedByName = "Deleted Fady";
                        item.Entity.ArchivedDateTime = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
