using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }

        public double BaseHealth { get; }
        public double Health
        {
            get { return health; }
            set
            {
                health = value;

                if (health > BaseHealth)
                {
                    health = BaseHealth;
                }

                if (health < 0)
                {
                    health = 0;
                    IsAlive = false;
                }
            }
        }
        public double BaseArmor { get; }
        public double Armor
        {
            get { return armor; }
            set
            {
                armor = value;

                if (armor < 0)
                {
                    armor = 0;
                }
            }
        }
        public double AbilityPoints { get; set; }
        public Bag Bag { get; set; }
        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            if (IsAlive)
            {
                if (hitPoints <= Armor)
                {
                    Armor -= hitPoints;
                }
                else
                {
                    Health -= (hitPoints - Armor);
                    Armor = 0;
                }
            }
            IsAlive = Health > 0;
        }

        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                item.AffectCharacter(this);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}