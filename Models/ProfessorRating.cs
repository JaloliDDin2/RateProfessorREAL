using Microsoft.CodeAnalysis;
using MyRateApp2.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static System.Reflection.Metadata.BlobBuilder;

namespace MyRateApp2.Models

{
    public partial class ProfessorRating
    {
        [Key]
        public int ProfRateId { get; set; }
        public int ProfGrade { get; set; }
        public string Comment { get; set; } = null!;
        public bool Attendance { get; set; }
        public bool WouldTakeAgain { get; set; }
        public int LevelOfDifficulty { get; set; }

        public double AverageQuality { get; set; }
        public string? CourseCode { get; set; }
        public bool Textbook { get; set; }
        public DateTime CreationDate { get; set; }
        public Grades Grade { get; set; }
        public bool ForCredit { get; set; }
        public int? ProfId { get; set; }
        public virtual Professor? Prof { get; set; }

        public double CalculateQuality()
        {
            // List all the individual rating properties
            var ratings = new List<int>
            {
                ProfGrade, LevelOfDifficulty
            };

            // Calculate the average
            double averageRating = ratings.Average();

            // Update the Overall property
            AverageQuality = averageRating;

            return averageRating;
        }
    }
}
