using Characters;

namespace Warriors
{
    public class Warrior : Character
    {
        int rage { get; set; }
        public Warrior(string name, int health, char atribute, int attackMax, int blockMax, int power) : base(name, health, atribute, attackMax, blockMax)
        {
            rage = power;
        }

        public override void specialPower()
        {
            AttackMax = AttackMax + rage;
        }
    }
}