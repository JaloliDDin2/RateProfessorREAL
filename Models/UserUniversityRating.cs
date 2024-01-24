using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MyRateApp2.Models
{
    [Keyless]
    public partial class UserUniversityRating
    {
        public int? UserId { get; set; }
        public int? UniRatingId { get; set; }

        public virtual UniversityRating? UniRating { get; set; }
        public virtual User? User { get; set; }
    }
}
