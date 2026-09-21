using FinalQuest.Abilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalQuest.Characters
{
    internal class Rogue : Character
    {
        public Rogue(string name) : base(name)
        {
            MaxHP = 90;
            HP = MaxHP;
            MaxMP = 50;
            MP = MaxMP;
            ATT = 16;
            DEF = 9;
            SPD = 20;

            Abilities.Add(new Backstab());
        }

        public override CharacterClass Job
        {
            get
            {
                return CharacterClass.Rogue;
            }
        }
    }
}
