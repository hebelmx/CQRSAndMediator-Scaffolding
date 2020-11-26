using System.Threading.Tasks;
using Application.Domain;
using Application.Persistency;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Infrastructure
{
    public class EntityModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var original = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (original != ValueProviderResult.None)
            {
                var originalValue = original.FirstValue;
                if (int.TryParse(originalValue, out var id))
                {
                    var dbContext = bindingContext.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
                    IEntity entity = null;
                    if (bindingContext.ModelType == typeof(Project))
                    {
                        entity = await dbContext.Set<Project>().FindAsync(id);
                    }
                    else if (bindingContext.ModelType == typeof(Employee))
                    {
                        entity = await dbContext.Set<Employee>().FindAsync(id);
                    }
                    else if (bindingContext.ModelType == typeof(Client))
                    {
                        entity = await dbContext.Set<Client>().FindAsync(id);
                    }
                    else if (bindingContext.ModelType == typeof(Budget))
                    {
                        entity = await dbContext.Set<Budget>().FindAsync(id);
                    }

                    bindingContext.Result = entity != null ? ModelBindingResult.Success(entity) : bindingContext.Result;
                }
            }
        }
    }
}