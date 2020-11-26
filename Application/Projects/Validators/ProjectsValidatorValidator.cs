using FluentValidation;
using Application;
using Application.DB;
using System;
using Application.Projects.Responses;
using Application.Projects.Commands;

namespace Application.Projects.Validators
{
    public class ProjectCreateValidator : AbstractValidator<ProjectsCreateCommand>
    {
        public ProjectCreateValidator()
        {
            RuleFor(d => d.Dto).NotNull();
        }
    }
}