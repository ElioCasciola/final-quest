using System;
using System.Collections.Generic;

using FinalQuest.Abilities;

namespace FinalQuest.Entities
{
    internal abstract class Entity
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int MP { get; set; }
        public int MaxMP { get; set; }
        public int ATT { get; set; }
        public int DEF { get; set; }
        public int SPD { get; set; }
        public List<Ability> Abilities { get; } = new List<Ability>();

        public bool IsDead => HP <= 0;

        public Entity(string name)
        {
            Name = name;
        }


        public virtual void ShowStats()
        {
            
            Console.WriteLine($"Name: {Name}");
            ShowCombatStats();
        }

        protected void ShowCombatStats()
        {
            Console.WriteLine($"HP: {HP}");
            Console.WriteLine($"MP: {MP}");
            Console.WriteLine($"ATT: {ATT}");
            Console.WriteLine($"DEF: {DEF}");
            Console.WriteLine($"SPD: {SPD}");
        }

        public int Attack(Entity target)
        {
            int damage = ATT - target.DEF;

            return target.TakeDamage(damage);
        }

        public int TakeDamage(int damage)
        {
            int actualDamage = Math.Max(1, damage);
            HP = Math.Max(0, HP - actualDamage);
            return actualDamage;
        }
    }
}
