using Application.Domain;

namespace Application.Infrastructure.Tags
{
    public class DepartmentSelectElementBuilder : EntitySelectElementBuilder<Project>
    {
        protected override int GetValue(Project instance)
        {
            return instance.Id;
        }

        protected override string GetDisplayValue(Project instance)
        {
            return instance.Name;
        }
    }
}