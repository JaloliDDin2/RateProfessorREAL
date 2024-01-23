using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyRateApp2.Models
{
    public partial class User: IdentityUser
    {
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public DateTime GraduationYear { get; set; }
        public string? UniName { get; set; }
        public int Password { get; set; }
        public int ProfRateId { get; set; }
        public int UniRatingId { get; set; }
        public int? UniversityId { get; set; }
        public virtual University University { get; set; }
    }
}
