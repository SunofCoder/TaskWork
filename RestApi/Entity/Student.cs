using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace RestApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]

        public string? StudentName { get; set; }
        public string? StudentLastName { get; set; }
        public int AssignmentWeek { get; set; }
        public float Result { get; set; }
    }
}

