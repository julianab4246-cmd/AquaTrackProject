using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AquaTrack.Models
{
    public class Fish
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Species { get; set; }

        [Range(0, 100)]
        public int Age { get; set; }

        // Foreign Key
        public int TankId { get; set; }

        // Navigation Properties
        public Tank Tank { get; set; }

        public List<Feeding> Feedings { get; set; } = new List<Feeding>();
    }
}
