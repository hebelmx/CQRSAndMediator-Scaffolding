using System.Collections.Generic;

namespace Application.ViewModels
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string HouseName { get; set; }
        public JobDto JobDto { get; set; }
        public IList<string> Jobs { get; set; }
    }
}