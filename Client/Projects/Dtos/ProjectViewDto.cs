using System;

namespace Client.Projects.Dtos
{
    public class ProjectViewDto
    {
        public int ProjectId { get; private set; }

        public string Name { get; private set; }

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