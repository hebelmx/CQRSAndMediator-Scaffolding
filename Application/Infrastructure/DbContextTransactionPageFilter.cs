using System;
using System.Threading.Tasks;
using Application.Persistency;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Infrastructure
{
    public class DbContextTransactionPageFilter : IAsyncPageFilter
    {
        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context) => Task.CompletedTask;

        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            var dbContext = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();

            try
            {
                await dbContext.BeginTransactionAsync();

                var actionExecuted = await next();
                if (actionExecuted.Exception != null && !actionExecuted.ExceptionHandled)
                {
                    await dbContext.Database.RollbackTransactionAsync();
                }
                else
                {
                    await dbContext.CommitTransactionAsync();
                }
            }
            catch (Exception)
            {
                await dbContext.Database.RollbackTransactionAsync();
                throw;
            }
        }
    }
}