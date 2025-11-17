using System;
using System.ComponentModel.DataAnnotations;

namespace AquaTrack.Models
{
    public class Feeding
    {
        public int Id { get; set; }

        [Required]
        public int FishId { get; set; }

        [Required]
        [StringLength(100)]
        public string FoodType { get; set; }

        [Required]
        public DateTime FedAt { get; set; } = DateTime.Now;

        public Fish Fish { get; set; }
    }
}
