using FinalQuest.Entities;
using FinalQuest.Characters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Metadata;

namespace FinalQuest.Abilities
{
    internal class Fireball : Ability
    {
        public Fireball()
            : base("Fireball", "Launches a powerfull ball of fire", 15) 
        {
        }
    public override bool ExecuteAbility(Character player, Entity target)
        {
            if (player.MP >= MPCost)
            {

                Console.WriteLine($"{player.Name} Casts {Name} ");
                int abilityDamage = player.ATT + 10 - target.DEF;
                target.HP = target.HP - abilityDamage;
                player.MP = player.MP - MPCost;
                return true;
            }
            else
            {
                Console.WriteLine("MP Is Not Enough!");
                return false;
            }
        }
    }
}
