using System;
using System.ComponentModel.DataAnnotations;
namespace Marketplace.Models
{
    public class Bid
    {
        public int Id { get; set; }
        [Required]
        public Module ModuleBidded { get; set; }
        [Required]
        public Instructor InstructorBidded { get; set; }
        //Should try and set default to ModuleMinimum, but can't figure out how
        [Required]
        public short HoursBid { get; set; }

        public bool Accepted { get; set; } = false;
    }
}