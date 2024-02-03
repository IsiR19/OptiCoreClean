using Microsoft.EntityFrameworkCore;
using OptiCore.Domain.Accounts;
using OptiCore.Domain.Core;
using OptiCore.Domain.Customers;
using OptiCore.Domain.Inventory;
using OptiCore.Domain.Orders;
using OptiCore.Domain.Payments;
using OptiCore.Domain.Suppliers;
using OptiCore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opticore.Persistance.DatabaseContext
{
    public class OptiCoreDbContext : DbContext
    {
        public OptiCoreDbContext(DbContextOptions<OptiCoreDbContext> options) : base(options)
        {
               
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<FinancialStatement> FinancialStatements { get; set; }
        public DbSet<Ledger> Ledgers { get; set;}
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Role> Roles { get; set; }  
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OptiCoreDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<AuditEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            { 
            entry.Entity.UpdatedOn = DateTime.Now;

                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedOn = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
