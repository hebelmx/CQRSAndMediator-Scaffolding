namespace Client.Projects.Actions.Delete
{
    public class DeleteProjectSuccessAction
    {
        public DeleteProjectSuccessAction(int id) =>
            Id = id;

        public int Id { get; }
    }
}