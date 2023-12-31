﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class User
    {
        public User()
        {
            Bets = new HashSet<Bet>();
        }
        public int UserId { get; set; }

        [MaxLength(10)]
        [Required]
        public string Username { get; set; }

        [MaxLength(10)]
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}
