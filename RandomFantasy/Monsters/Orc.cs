using System;
using System.Collections.Generic;
using System.Text;

namespace FinalQuest.Monsters
{
    internal class Orc : Monster
    {
        public Orc() : base("Orc")
        {
            MaxHP = 75;
            HP = MaxHP;
            MaxMP = 10;
            MP = MaxMP;
            ATT = 16;
            DEF = 10;
            SPD = 6;
        }
    }
}
