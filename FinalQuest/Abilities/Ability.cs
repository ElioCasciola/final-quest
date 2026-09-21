using FinalQuest.Entities;

namespace FinalQuest.Abilities
{
    internal abstract class Ability
    {
        public string Name { get; }
        public string Description { get; }
        public int MPCost { get; }

        protected Ability(string name, string description, int mpCost)
        {
            Name = name;
            Description = description;
            MPCost = mpCost;
        }

        public bool CanUse(Entity user)
        {
            return user.MP >= MPCost;
        }

        public bool TryExecute(Entity user, Entity target, out int damageDealt)
        {
            damageDealt = 0;

            if (!CanUse(user))
            {
                return false;
            }

            damageDealt = ApplyEffect(user, target);
            user.MP -= MPCost;

            return true;
        }

        protected abstract int ApplyEffect(Entity user, Entity target);
    }
}
