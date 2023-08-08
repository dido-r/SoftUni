﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class Country
    {
        public Country()
        {
            Towns = new HashSet<Town>();
        }
        public int CountryId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; }
    }
}
