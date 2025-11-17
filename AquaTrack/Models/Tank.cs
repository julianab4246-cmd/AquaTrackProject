using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AquaTrack.Models
{
    public class Tank
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TankName { get; set; }

        [Range(1, 10000)]
        public double VolumeInLiters { get; set; }

        [Required]
        public string WaterType { get; set; } 

        public List<Fish> Fish { get; set; } = new List<Fish>();
    }
}
