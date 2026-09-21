using FinalQuest.Abilities;

namespace FinalQuest.Characters
{
    internal class Mage : Character
    {
        public Mage(string name) : base(name)
        {
            MaxHP = 75;
            HP = MaxHP;
            MaxMP = 100;
            MP = MaxMP;
            ATT = 22;
            DEF = 6;
            SPD = 10;

            Abilities.Add(new Fireball());
        }

        public override CharacterClass Job
        {
            get
            {
                return CharacterClass.Mage;
            }
        }
    }
}
