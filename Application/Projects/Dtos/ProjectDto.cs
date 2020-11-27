using System;
using Application.Persistence;

namespace Application.Projects.Dtos
{
    public class ProjectDto : Entity
    {
        public string Name { get; init; }

        public DateTime StartDate { get; init; }

        public DateTime EndDate { get; init; }

        public DateTime? ActualEndDate { get; init; }

        public int GuaranteePeriodInMonths { get; init; }

        public bool IsActive { get; init; }

        public string ShortName { get; init; }

        public int CustomerId { get; init; }

        public int ManagerId { get; init; }

        public int ContractId { get; init; }
    }
}