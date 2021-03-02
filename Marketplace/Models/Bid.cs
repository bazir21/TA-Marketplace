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
        [Required]
        public short HoursBid { get; set; }
    }
}