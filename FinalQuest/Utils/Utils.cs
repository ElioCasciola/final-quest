using FinalQuest.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalQuest.Utils
{
    internal class Utils
    {
        public void Attack(Entity attacker, Entity target )
        {
            int damage = attacker.ATT - target.DEF;
            if (damage < 1)
            {
                damage = 1;
            }
            target.HP = target.HP - damage;
            Console.WriteLine($"{attacker.Name} attacks {target.Name} for {damage} damage!");
        }
    }
}
