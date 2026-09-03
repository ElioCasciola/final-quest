using System;
using System.Collections.Generic;
using System.Text;

    namespace FinalQuest.Monsters
    {
        internal class Goblin : Monster
        {
            public Goblin() : base("Goblin")
            {
                MaxHP = 30;
                HP = MaxHP;
                MaxMP = 10;
                MP = MaxMP;
                ATT = 8;
                DEF = 3;
                SPD = 12;
            }
        }
    }
