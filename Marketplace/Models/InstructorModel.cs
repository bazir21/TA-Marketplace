using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Identity; 
using Marketplace.Roles;

namespace Marketplace.Models
{
    public class InstructorModel : UserModel
    {

        [StringLength(5)]
        public string Level { get; set; }

        [Required]
        [EmailAddress]
        [JsonPropertyName("emailTCD")]
        private string TCDEmail { get; set; }

        public InstructorRole role { get; set; }
        /* public short minHoursAllowedSemesterOne { get; set; }
        public short maxHoursAllowedSemesterOne { get; set; }

        public short minHoursAllowedSemesterTwo { get; set; }
        public short maxHoursAllowedSemesterTwo { get; set; }

        public short HoursAvailableSemesterOne { get; set; }
        public short HoursAvailableSemesterTwo { get; set; }
        
        public string[] ModulesWhereInstructor { get; set; }
        public string[] OutstandingBids { get; set; }
        //List of modules where the instructor has been accepted. One to many
        //public ICollection<ModuleModel> ModulesWhereInstructor { get; set; }
        //Bids not yet accepted or denied by admins. One to many
        public ICollection<BidModel> OutstandingBids { get; set; } */

        public override String ToString() => Name;
    }
}