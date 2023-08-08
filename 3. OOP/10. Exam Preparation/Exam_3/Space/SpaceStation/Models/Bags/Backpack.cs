﻿using SpaceStation.Models.Bags.Contracts;
using System.Collections.Generic;

namespace SpaceStation.Models.Bags
{
    class Backpack : IBag
    {
        public Backpack()
        {
            Items = new List<string>();
        }
        public ICollection<string> Items { get; }
    }
}
