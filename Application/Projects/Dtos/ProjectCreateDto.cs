using System;
using Application.Domain;
using Application.Persistence;

namespace Application.Projects.Dtos
{
    public class ProjectCreateDto : Entity
    {
        public string Name { get; set; }

        public Budget Budget { get; set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public DateTime? ActualEndDate { get; private set; }

        public int GuaranteePeriodInMonths { get; private set; }

        public bool IsActive { get; private set; }

        public string ShortName { get; private set; }

        public int CustomerId { get; private set; }

        public int ManagerId { get; private set; }

        public int ContractId { get; private set; }
    }
}