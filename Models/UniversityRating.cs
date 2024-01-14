using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyRateApp2.Models
{
    public partial class UniversityRating
    {
        [Key]
        public int UniRatingId { get; set; }
        public int Reputation { get; set; }
        public int Opportunity { get; set; }
        public int Happiness { get; set; }
        public int Facilities { get; set; }
        public int Location { get; set; }
        public int Safety { get; set; }
        public int Clubs { get; set; }
        public int Social { get; set; }
        public int Internet { get; set; }
        public int Food { get; set; }
        public int Overall { get; set; }
        public DateTime CreationDate { get; set; }
        public string Comment { get; set; } = null!;
        public int? UniId { get; set; }

        public virtual University? Uni { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
