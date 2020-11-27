using FluentValidation;
using Application;
using Application.Domain;
using System;
using Application.Projects.Responses;
using Application.Projects.Commands;

namespace Application.Projects.Validators
{
    public class ProjectGetByIdValidator : AbstractValidator<ProjectsGetByIdCommand>
    {
        public ProjectGetByIdValidator()
        {
            RuleFor(d => d.Dto).NotNull();
        }
    }
}