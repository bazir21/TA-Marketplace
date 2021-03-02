using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Marketplace.Models
{
    public class Module
    {
        [Required]
        public string ModuleName { get; set; }
        [Required]
        public string ModuleCode { get; set; }
        [Required]
        public short AcademicYear { get; set; }
        [Required]
        public short Semester { get; set; }
        public ICollection<Administrator> Lecturers { get; set; }
        public ICollection<Bid> Bids { get; }
        public ICollection<Instructor> Instructors { get; set; }
        [Required]
        public int TotalHoursAvailable { get; set; }
        [Required]
        public short MaxHoursPerInstructor { get; set; }
        [Required]
        public short MinHoursPerInstructor { get; set; }
        public ICollection<string> KeywordsAssociatedWithModule { get; set; }
    }
}