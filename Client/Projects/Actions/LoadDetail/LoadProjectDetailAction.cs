namespace Client.Projects.Actions.LoadDetail
{
    public class LoadProjectDetailAction
    {
        public LoadProjectDetailAction(int id) =>
            Id = id;

        public int Id { get; set; }
    }
}