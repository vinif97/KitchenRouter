using KitchenRouter.Domain.Models;
using KitchenRouter.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace KitchenRouter.Infrastructure.Context
{
    public class KitchenRouterContext : DbContext
    {
        public KitchenRouterContext(DbContextOptions<KitchenRouterContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }

        public override int SaveChanges()
        {
            HandleCreatAndDeleteDate();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleCreatAndDeleteDate();
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        private void HandleCreatAndDeleteDate()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Deleted));

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.CurrentValues[nameof(BaseEntity.CreatedAt)] = DateTime.Now;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.CurrentValues[nameof(BaseEntity.IsDeleted)] = true;
                }
            }
        }
    }
}