using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Domain
{
    public class Budget : IEntity
    {
        [Column("DepartmentID")]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Allowance { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        public int? ManagerEmployeeId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Employee ManagerEmployee { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}