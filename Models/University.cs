using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyRateApp2.Models
{
    public partial class University
    {
        public University()
        {
            Professors = new HashSet<Professor>();
        }
        [Key]
        public int UniId { get; set; }
        public string? Name { get; set; }
        public string Country { get; set; } = null!;
        public string State { get; set; } = null!;
        public string? City { get; set; }
        public string? Website { get; set; }
        public string? Email { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:N1}", ApplyFormatInEditMode = true)]
        public double? OverallQuality { get; set; }
        public bool IsApproved { get; set; } = false;
        public ICollection<UniversityRating> UniversityRatings { get; set; } = new HashSet<UniversityRating>();
        public virtual ICollection<Professor> Professors { get; set; }
    }
}
