using System.Threading;
using System.Threading.Tasks;
using Application.Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistency
{
    public interface IApplicationDbContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<Quotation> Quotations { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Budget> Budgets { get; set; }
        DbSet<Employee> Employees { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();
    }
}