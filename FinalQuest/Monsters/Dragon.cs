using System;
using System.Collections.Generic;
using System.Text;

namespace FinalQuest.Monsters
{
    internal class Dragon : Monster
    {
        public Dragon() : base("Dragon") 
        {
            MaxHP = 180;
            HP = MaxHP;
            MaxMP = 60;
            MP = MaxMP;
            ATT = 24;
            DEF = 14;
            SPD = 14;
        }
    }
}
