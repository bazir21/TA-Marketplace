using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Marketplace.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        [StringLength(5)]
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
        
        //List of modules where the instructor has been accepted. One to many
        public ICollection<Module> ModulesWhereInstructor { get; set; }
        //Bids not yet accepted or denied by admins. One to many
        public ICollection<Bid> OutstandingBids { get; set; }
    }
}