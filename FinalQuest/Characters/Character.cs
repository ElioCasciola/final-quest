using System;
using System.Collections.Generic;
using System.Text;
using FinalQuest.Entities;
using FinalQuest.Abilities;

namespace FinalQuest.Characters
{
    

    internal abstract class Character : Entity
    {
        public abstract CharacterClass Job { get; }
        
        public Character(string name) :base(name)
        {
        }

        public override void ShowStats()
        {
            Console.WriteLine("=== CHARACTER ===");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Job: {Job}");
            ShowCombatStats();
        }


    }
}
