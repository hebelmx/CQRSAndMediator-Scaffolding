using System.Threading;
using System.Threading.Tasks;
using Application.Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence
{
    public interface IApplicationDbContext : IDbContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<Quotation> Quotations { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Budget> Budgets { get; set; }
        DbSet<Employee> Employees { get; set; }

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();
    }
}