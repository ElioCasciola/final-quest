using FinalQuest.Entities;
using FinalQuest.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalQuest.Abilities
{
    internal abstract class Ability
    {
        public string Name { get; }
        public string Description { get; }
        public int MPCost { get; }

        protected Ability(string name, string description, int mpCost)
        {
            Name = name;
            Description = description;
            MPCost = mpCost;
        }

        public abstract bool ExecuteAbility(Character player, Entity target);
    }
}
