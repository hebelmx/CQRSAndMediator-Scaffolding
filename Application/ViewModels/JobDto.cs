namespace Application.ViewModels
{
    public class JobDto
    {
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public PersonDto Manager { get; set; }
    }
}