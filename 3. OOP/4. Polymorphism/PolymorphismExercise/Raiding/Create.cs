using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public static class Create
    {
        public static BaseHero CreateHero(string type, string name)
        {
            BaseHero hero = null;

            switch (type)
            {
                case "Druid":
                    hero = new Druid(name);
                    break;
                case "Paladin":
                    hero = new Paladin(name);
                    break;
                case "Rogue":
                    hero = new Rogue(name);
                    break;
                case "Warrior":
                    hero = new Warrior(name);
                    break;
            }
            return hero;
        }
    }
}
