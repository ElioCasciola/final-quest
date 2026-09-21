using FinalQuest.Abilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalQuest.Characters
{
    internal class Warrior : Character
    {
        public Warrior(string name) : base(name)
        {
            MaxHP = 120;
            HP = MaxHP;
            MaxMP = 30;
            MP = MaxMP;
            ATT = 15;
            DEF = 15;
            SPD = 8;

            Abilities.Add(new PowerStrike());
        }

        public override CharacterClass Job
        {
            get
            {
                return CharacterClass.Warrior;
            }
        }
    }
}
