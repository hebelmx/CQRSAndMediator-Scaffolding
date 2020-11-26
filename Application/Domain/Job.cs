namespace Application.Domain
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public Person Manager { get; set; }
    }
}
