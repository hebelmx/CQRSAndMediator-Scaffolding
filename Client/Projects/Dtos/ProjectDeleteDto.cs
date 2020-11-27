using System;

namespace Client.Projects.Dtos
{
    public class ProjectDeleteDto
    {
        public ProjectDeleteDto(int id)
        {
            Id = id;
        }

        public int Id { get; init; }
    }
}