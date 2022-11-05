using Characters;

namespace Mages
{
    public class Mage : Character
    {   
        int RegenHealth { get; set; }
        public Mage(string name, int health, char atribute, int attackMax, int blockMax, int power) : 
            base(name, health, atribute, attackMax, blockMax)
        {
            RegenHealth = power;
        }

        public override void SpecialPower()
        {
            Health = Health + RegenHealth;
        }
    }
}