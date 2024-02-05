using Measure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Infrastructure.Context
{
    public class UserDbContext : DbContext, IUserDbContext
    {
        public DbSet<User> User {  get; set; }
        public DbSet<FemaleMeasures> FemaleMeasures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("MARC");
        //    }
        //}

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

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
