﻿using System.Collections.Generic;

namespace Footballers.Data.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public int Trophies { get; set; }
        public ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}
