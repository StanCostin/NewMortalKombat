using Characters;

namespace Mages
{
    public class Mage : Character
    {   
        int regenHealth { get; set; }
        public Mage(string name, int health, char atribute, int attackMax, int blockMax, int power) : base(name, health, atribute, attackMax, blockMax)
        {
            regenHealth = power;
        }

        public override void specialPower()
        {
            Health = Health + regenHealth;
        }
    }
}