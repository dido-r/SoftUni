﻿using System.ComponentModel.DataAnnotations;

namespace Homies.Services.Models
{
    public class EventEditModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 15)]
        public string Description { get; set; } = null!;

        [Required]
        public string Start { get; set; } = null!;

        [Required]
        public string End { get; set; } = null!;

        [Display(Name = "Type of Event")]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
