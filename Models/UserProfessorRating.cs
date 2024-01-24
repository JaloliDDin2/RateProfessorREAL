using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MyRateApp2.Models
{
    [Keyless]
    public partial class UserProfessorRating
    {   
        public int? UserId { get; set; }
        public int? ProfRateId { get; set; }

        public virtual ProfessorRating? ProfRate { get; set; }
        public virtual User? User { get; set; }
    }
}
