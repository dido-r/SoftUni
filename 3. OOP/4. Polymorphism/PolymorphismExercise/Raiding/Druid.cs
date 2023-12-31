﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    class Druid : BaseHero
    {
        public Druid(string name) : base(name, 80) { }
        public override string CastAbility()
        {
            return $"Druid - {Name} healed for {Power}";
        }
    }
}
