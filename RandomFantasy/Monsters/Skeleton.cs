using System;
using System.Collections.Generic;
using System.Text;

namespace FinalQuest.Monsters
{
    internal class Skeleton : Monster
    {
        public Skeleton() : base("Skeleton")
        {
            MaxHP = 45;
            HP = MaxHP;
            MaxMP = 0;
            MP = MaxMP;
            ATT = 11;
            DEF = 7;
            SPD = 8;
        }
    }
}
