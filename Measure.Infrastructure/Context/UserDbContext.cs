using Measure.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Measure.Infrastructure.Context
{
    public class UserDbContext : DbContext, IUserDbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users {  get; set; }
        public DbSet<FemaleMeasures> FemaleMeasures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        public override Task<int>SaveChangesAsync(CancellationToken ct = default)
        {
            PreSaveChanges();
            return base.SaveChangesAsync(ct);
        }
        private void PreSaveChanges()
        {
            var entities = ChangeTracker
                .Entries()
                .Where(e => e.Entity is User && (e.State == EntityState.Added))
                .Select(e => e.Entity as User);

            foreach (var entity in entities)
            {
                if (entity != null && entity.Created == default)
                {
                    entity.Created = DateTimeOffset.UtcNow;
                }
            }
        }
    }
}
