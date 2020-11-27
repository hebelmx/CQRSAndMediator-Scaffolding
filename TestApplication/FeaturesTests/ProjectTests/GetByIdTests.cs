using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Domain;
using Application.Projects.Commands;
using Application.Projects.Dtos;
using Application.ViewModels;
using FakeItEasy.Sdk;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace TestApplication.Features.Project
{
    [Collection(nameof(SliceFixture))]
    public class GetByIdTests
    {
        private readonly SliceFixture _fixture;

        public GetByIdTests(SliceFixture fixture) => _fixture = fixture;

        [Fact]
        public async Task Should_retrieve_project_When_Id_is_Valid()
        {
            var budget = new Budget
            {
                Allowance = 1000,
                Name = "New Budget"
            };

            var project = new Application.Domain.Project();

            var query = new ProjectsGetByIdCommand(new ProjectGetByIdDto()
            {
                id = 1
            });

            await _fixture.ExecuteDbContextAsync(async (context, mediator) =>
            {
                await context.Projects.AddAsync(project);

                var result1 = await mediator.Send(query);
                var result2 = await mediator.Send(query);
            });

            // result2.ShouldNotBeNull();
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