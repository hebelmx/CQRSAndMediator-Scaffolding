using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Domain
{
    public class Quotation : IEntity
    {
        [Column("EnrollmentID")]
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public int ClientId { get; set; }

        [DisplayFormat(NullDisplayText = "No grade")]
        public Status? Status { get; set; }

        public Project Project { get; set; }
        public Client Client { get; set; }
    }
}