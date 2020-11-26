using DelegateDecompiler;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Domain
{
    public class Person : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [Display(Name = "Full Name")]
        [Computed]
        public string FullName => LastName + ", " + FirstMidName;

        public DateTime Birthday { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}