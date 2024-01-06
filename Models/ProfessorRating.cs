using MyRateApp2.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyRateApp2.Models

{
    public partial class ProfessorRating
    {
        [Key]
        public long ProfRateId { get; set; }
        public ProfGrade ProfGrade { get; set; }
        public string Comment { get; set; } = null!;
        public bool Attendance { get; set; }
        public bool WouldTakeAgain { get; set; }
        public LevelOfDifficulty LevelOfDifficulty { get; set; }
        public string? CourseCode { get; set; }
        public bool Textbook { get; set; }
        public DateTime CreationDate { get; set; }
        public Grades Grade { get; set; }
        public bool ForCredit { get; set; }
        public long? ProfId { get; set; }
        public virtual Professor? Prof { get; set; }
    }
}
