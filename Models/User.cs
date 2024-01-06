using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyRateApp2.Models
{
    public partial class User: IdentityUser
    {
        [Key]
        public long UserId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string UniName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime GraduationYear { get; set; }
        public int Password { get; set; }
        public int ProfRateId { get; set; }
        public int UniRatingId { get; set; }
    }
}
