using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json;

namespace Marketplace.Models
{
    public class ModuleModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string ModuleName { get; set; }
        [Required]
        [StringLength(15)]
        public string ModuleCode { get; set; }
        [Required]
        public short AcademicYear { get; set; }
        [Required]
        public short Semester { get; set; }
        public ICollection<AdministratorModel> Lecturers { get; set; }
        public ICollection<BidModel> Bids { get; }
        public ICollection<InstructorModel> Instructors { get; set; }
        [Required]
        public int TotalHoursAvailable { get; set; }
        [Required]
        public short MaxHoursPerInstructor { get; set; }
        [Required]
        public short MinHoursPerInstructor { get; set; }

        public short HoursFilled { get; set; }
        //public ICollection<String> KeywordsAssociatedWithModule { get; set; }

        public override String ToString() => JsonSerializer.Serialize<ModuleModel>(this);
    }
}