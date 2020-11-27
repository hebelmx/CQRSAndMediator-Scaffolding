using Client.Projects.Dtos;

namespace Client.Projects.Actions.Update
{
    public class UpdateProjectAction
    {
        public UpdateProjectAction(int id, ProjectUpdateDto project) =>
            (Id, Project) = (id, project);

        public int Id { get; }

        public ProjectUpdateDto Project { get; }
    }
}