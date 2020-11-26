using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Domain;
using Application.Projects.Commands;
using Application.ViewModels;
using FakeItEasy.Sdk;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace TestApplication.Features.Project
{
    [Collection(nameof(SliceFixture))]
    public class CreateTests
    {
        private readonly SliceFixture _fixture;

        public CreateTests(SliceFixture fixture) => _fixture = fixture;

        [Fact]
        public async Task Should_create_new_project()
        {
            var command = new ProjectsCreateCommand(new ProjectCreateDto
            {
                Name = "New project"
            });

            var budget = new Budget
            {
                Allowance = 1000,
                Name = "New Budget"
            };

            await _fixture.ExecuteDbContextAsync(async (context, mediator) =>
            {
                await context.Budgets.AddAsync(budget);
                var result = await mediator.Send(command);
            });

            var created = await _fixture.ExecuteDbContextAsync(db => db.Projects.Where(c => c.Name == command.Dto.Name).SingleOrDefaultAsync());

            created.ShouldNotBeNull();
            //created.Budget.ShouldNotBeNull();
            //created.Id.ShouldBeGreaterThanOrEqualTo(1);
            //created.Budget.Id.ShouldBeGreaterThanOrEqualTo(1);

            //created.Id.ShouldBeGreaterThanOrEqualTo(1);
            //created.Budget.Id.ShouldBeGreaterThanOrEqualTo(1);

            //created.Name.ShouldBe(command.Dto.Name);
            //created.Budget.Name.ShouldBe(budget.Name);
        }
    }
}