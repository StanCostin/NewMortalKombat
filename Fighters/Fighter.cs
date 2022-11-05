using Characters;

namespace Fighters
{
    public class Fighter : Character
    {
        int footKick { get; set; }
        public Fighter(string name, int health, char atribute, int attackMax, int blockMax, int power) : 
            base(name, health, atribute, attackMax, blockMax) {
            footKick = power;
        }

        public override void SpecialPower()
        {
            Health = Health - footKick;
        }

    }
}