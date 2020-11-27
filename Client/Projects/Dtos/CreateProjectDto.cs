using System;

namespace Client.Projects.Dtos
{
    public class ProjectCreateDto
    {
        public ProjectCreateDto(string title, bool completed, int userId) =>
            (Title, Completed, UserId) = (title, completed, userId);

        public string Title { get; }

        public bool Completed { get; }

        public int UserId { get; }

        public string Name { get; set; }

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