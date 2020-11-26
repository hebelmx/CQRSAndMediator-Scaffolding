using Application.Logic.Projects.Commands;
using FluentValidation;

namespace Application.Logic.Projects.Validators
{
    public class ProjectCreateValidator : AbstractValidator<ProjectsCreateCommand>
    {
        public ProjectCreateValidator()
        {
            RuleFor(d => d.Dto).NotNull();
        }
    }
}