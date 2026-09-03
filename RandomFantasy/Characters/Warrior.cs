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
