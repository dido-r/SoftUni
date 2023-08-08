using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Character> heroes;
        private readonly List<Item> items;
        public WarController()
        {
            heroes = new List<Character>();
            items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            if (args[0] != "Priest" && args[0] != "Warrior")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, args[0]));
            }

            Character hero = default;

            if (args[0] == nameof(Priest))
            {
                hero = new Priest(args[1]);
            }
            else if (args[0] == nameof(Warrior))
            {
                hero = new Warrior(args[1]);
            }

            heroes.Add(hero);

            return string.Format(SuccessMessages.JoinParty, args[1]);
        }

        public string AddItemToPool(string[] args)
        {
            if (args[0] != "HealthPotion" && args[0] != "FirePotion")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, args[0]));
            }

            Item item = default;

            if (args[0] == nameof(HealthPotion))
            {
                item = new HealthPotion();
            }
            else if (args[0] == nameof(FirePotion))
            {
                item = new FirePotion();
            }

            items.Add(item);

            return string.Format(string.Format(SuccessMessages.AddItemToPool, args[0]));
        }

        public string PickUpItem(string[] args)
        {
            if (!heroes.Any(x => x.Name == args[0]))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
            }

            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            var item = items[items.Count - 1];
            heroes.First(x => x.Name == args[0]).Bag.AddItem(item);
            items.RemoveAt(items.Count - 1);

            return string.Format(SuccessMessages.PickUpItem, args[0], item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            if (!heroes.Any(x => x.Name == args[0]))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
            }

            var hero = heroes.First(x => x.Name == args[0]);
            var item = hero.Bag.GetItem(args[1]);
            hero.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, args[0], args[1]);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            string status = "Alive";

            foreach (var hero in heroes.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                if (!hero.IsAlive)
                {
                    status = "Dead";
                }
                sb.AppendLine(string.Format(SuccessMessages.CharacterStats, hero.Name, hero.Health, hero.BaseHealth, hero.Armor, hero.BaseArmor, status));
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            if (!heroes.Any(x => x.Name == args[0]))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
            }
            if (!heroes.Any(x => x.Name == args[1]))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[1]));
            }

            var attacker = heroes.First(x => x.Name == args[0]);
            var receiver = heroes.First(x => x.Name == args[1]);

            if (!(attacker is IAttacker))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, args[0]));
            }

            (attacker as IAttacker).Attack(receiver);

            var result = string.Format(SuccessMessages.AttackCharacter, attacker.Name, receiver.Name, attacker.AbilityPoints, receiver.Name, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor);

            if (!receiver.IsAlive)
            {
                result += Environment.NewLine + string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name);
            }

            return result;
        }

        public string Heal(string[] args)
        {
            if (!heroes.Any(x => x.Name == args[0]))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
            }
            if (!heroes.Any(x => x.Name == args[1]))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[1]));
            }

            var healer = heroes.First(x => x.Name == args[0]);
            var receiver = heroes.First(x => x.Name == args[1]);

            if (!(healer is IHealer))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, args[0]));
            }

            (healer as IHealer).Heal(receiver);

            return string.Format(SuccessMessages.HealCharacter, healer.Name, receiver.Name, healer.AbilityPoints, receiver.Name, receiver.Health);
        }
    }
}
