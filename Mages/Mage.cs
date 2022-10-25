using Characters;

namespace Mages
{
    public class Mage : Character
    {


        int regenHealth { get; set; }
        public Mage(string name, int health, char atribute, int atckMax, int blckMax, int power) : base(name, health, atribute, atckMax, blckMax)
        {
            regenHealth = power;
        }

        public override void specialPower()
        {
            Health = Health + regenHealth;
        }
    }
}