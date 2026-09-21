using FinalQuest.Entities;

namespace FinalQuest.Abilities
{
    internal class Backstab : Ability
    {
        public Backstab()
            : base("Backstab", "Strikes a weak point, ignoring half of the target's defense.", 10)
        {
        }

        protected override int ApplyEffect(Entity user, Entity target)
        {
            int reducedDefense = target.DEF / 2;
            int damage = user.ATT + 5 - reducedDefense;

            return target.TakeDamage(damage);
        }
    }
}
