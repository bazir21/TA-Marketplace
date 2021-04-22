using System;
using System.ComponentModel.DataAnnotations;
namespace Marketplace.Models
{
    public class BidModel
    {
        public int Id { get; set; }
        [Required]
        public int ModuleModelId { get; set; }
        [Required]
        public string InstructorBiddedId { get; set; }
        //Should try and set default to ModuleMinimum, but can't figure out how
        [Required]
        public short HoursBid { get; set; }

        public BidStatus Accepted { get; set; } = 0; // 0 is pending, 1 is accepted, 2 is rejected
    }

    public enum BidStatus
    {
        Pending,
        Accepted,
        Rejected
    }
}