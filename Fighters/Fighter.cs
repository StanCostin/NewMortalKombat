using Characters;

namespace Fighters
{
    public class Fighter : Character
    {
        int footKick { get; set; }
        public Fighter(string name, int health, char atribute, int atckMax, int blckMax, int power) : base(name, health, atribute,atckMax, blckMax) {
            footKick = power;
        }

        public override void specialPower()
        {
            Health = Health - footKick;
        }

    }
}