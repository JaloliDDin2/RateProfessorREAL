using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyRateApp2.Models
{
    public partial class Professor
    {
        [Key]
        public long ProfId { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Department { get; set; }
        public int? UniId { get; set; }


        public virtual University? Uni { get; set; }
        public virtual ProfessorRating? ProfessorRating { get; set; }
    }
}
