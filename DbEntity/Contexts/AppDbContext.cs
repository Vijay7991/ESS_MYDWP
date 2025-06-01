using DbEntity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DBEnity.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbLeave> Leaves { get; set; }
        public DbSet<DbTask> Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // DbUser configuration
            modelBuilder.Entity<DbUser>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<DbUser>()
                .Property(u => u.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<DbUser>()
                .Property(u => u.UserName)
                .IsRequired();

            modelBuilder.Entity<DbUser>()
                .Property(u => u.Email)
                .IsRequired();

            // DbLeave configuration
            modelBuilder.Entity<DbLeave>()
                .Property(l => l.Status)
                .HasDefaultValue("Pending");

            modelBuilder.Entity<DbLeave>()
                .Property(l => l.Reason)
                .HasDefaultValue(string.Empty);

            modelBuilder.Entity<DbLeave>()
                .HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // DbTask configuration
            modelBuilder.Entity<DbTask>()
                .Property(t => t.Title)
                .IsRequired();

            modelBuilder.Entity<DbTask>()
                .Property(t => t.Description)
                .HasDefaultValue(string.Empty);

            modelBuilder.Entity<DbTask>()
                .Property(t => t.IsCompleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<DbTask>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public override int SaveChanges()
        {
            SetTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void SetTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is DbUser && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (DbUser)entry.Entity;
                entity.UpdatedAt = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
