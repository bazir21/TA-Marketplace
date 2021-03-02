using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Marketplace.Models
{
    public class Instructor
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Level { get; set; }
        [Required]
        [EmailAddress]
        private string TCDEmail { get; set; }
        public short minHoursAllowedSemesterOne { get; set; }
        public short maxHoursAllowedSemesterOne { get; set; }

        public short minHoursAllowedSemesterTwo { get; set; }
        public short maxHoursAllowedSemesterTwo { get; set; }

        public short HoursAvailableSemesterOne { get; set; }
        public short HoursAvailableSemesterTwo { get; set; }
        public ICollection<Module> Modules { get; set; }
        public ICollection<Bid> OutstandingBids { get; set; }
    }
}