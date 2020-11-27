namespace Client.Projects.Dtos
{
    public class ProjectUpdateDto
    {
        public ProjectUpdateDto(string title, bool completed, int userId) =>
            (Title, Completed, UserId) = (title, completed, userId);

        public string Title { get; }

        public bool Completed { get; }

        public int UserId { get; }
    }
}