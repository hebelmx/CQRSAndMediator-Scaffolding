using Application.Domain;

namespace Application.Infrastructure.Tags
{
    public class InstructorSelectElementBuilder : EntitySelectElementBuilder<Employee>
    {
        protected override int GetValue(Employee instance)
        {
            return instance.Id;
        }

        protected override string GetDisplayValue(Employee instance)
        {
            return instance.FullName;
        }
    }
}