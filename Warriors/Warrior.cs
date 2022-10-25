using Characters;
using System.Reflection.PortableExecutable;

namespace Warriors
{
    public class Warrior : Character
    {
        int rage { get; set; }
        public Warrior(string name, int health, char atribute, int atckMax, int blckMax, int power) : base(name, health, atribute, atckMax, blckMax)
        {
            rage = power;
        }

        public override void specialPower()
        {
            AttackMax = AttackMax + rage;
        }
    }
}