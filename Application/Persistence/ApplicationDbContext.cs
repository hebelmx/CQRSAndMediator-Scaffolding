using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Application.Domain;
using ExxerProject.Persistence.Configurators.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        private IDbContextTransaction _currentTransaction;

        public DbSet<Project> Projects { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Project>(new ProjectTypeConfiguration(modelBuilder));

            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Budget>().ToTable("Budgets");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Quotation>().ToTable("Quotations");
        }

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();

                await (_currentTransaction?.CommitAsync() ?? Task.CompletedTask);
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                await (_currentTransaction?.RollbackAsync() ?? Task.CompletedTask);
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}