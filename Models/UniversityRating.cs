using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public double Overall { get; set; }
        public DateTime CreationDate { get; set; }
        public string Comment { get; set; } = null!;
        public int? UniId { get; set; }
        public University? Uni { get; set; }

        public double CalculateOverallRating()
        {
            // List all the individual rating properties
            var ratings = new List<int>
        {
            Reputation, Opportunity, Happiness, Facilities, Location,
            Safety, Clubs, Social, Internet, Food
        };

            // Calculate the average
            double averageRating = ratings.Average();

            // Update the Overall property
            Overall = averageRating;

            return averageRating;
        }
    }

}
