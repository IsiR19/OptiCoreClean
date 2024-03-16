using Microsoft.EntityFrameworkCore;
using Opticore.Persistence.Configurations;
using OptiCore.Domain.Accounts;
using OptiCore.Domain.Agents;
using OptiCore.Domain.Commissions;
using OptiCore.Domain.Core;
using OptiCore.Domain.CP;
using OptiCore.Domain.Customers;
using OptiCore.Domain.HeadOffices;
using OptiCore.Domain.Inventory;
using OptiCore.Domain.Leads;
using OptiCore.Domain.Orders;
using OptiCore.Domain.Payments;
using OptiCore.Domain.Suppliers;
using OptiCore.Domain.Users;

namespace Opticore.Persistence.DatabaseContext
{
    public class OptiCoreDbContext : DbContext
    {
        public OptiCoreDbContext(DbContextOptions<OptiCoreDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<FinancialStatement> FinancialStatements { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<HeadOffice> HeadOffices { get; set; }
        public DbSet<Cp> Cp { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<UserHierarchy> UserHierarchy { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OptiCoreDbContext).Assembly);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.Entity<UserHierarchy>()
            .HasOne(uh => uh.ParentUser)
            .WithMany(u => u.ChildHierarchies)
            .HasForeignKey(uh => uh.ParentUserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserHierarchy>()
            .HasOne(uh => uh.ChildUser)
            .WithOne(u => u.ParentHierarchy)
            .HasForeignKey<UserHierarchy>(uh => uh.ChildUserId)
            .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Commission>()
            .HasOne(c => c.User)
            .WithMany(u => u.Commissions)
            .HasForeignKey(c => c.UserId);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<AuditEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.UpdatedOn = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedOn = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}