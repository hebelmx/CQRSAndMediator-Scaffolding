﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DelegateDecompiler;

namespace Application.Domain
{
    public class Employee : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column("FirstName")]
        [StringLength(50)]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [Computed]
        public string FullName => LastName + ", " + FirstMidName;

        public ICollection<Project> Projects { get; private set; } = new List<Project>();
    }
}