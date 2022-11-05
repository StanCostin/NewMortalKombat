namespace Characters
{
    //un proiect pentru o singura clasa e putin cam mult..
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public char Atribute { get; set; }
        public int AttackMax { get; set; }
        public int BlockMax { get; set; }

        public Character(string name, int health, char atribute, int attackMax, int blockMax)
        {
            Name = name;
            Health = health;
            Atribute = atribute;
            AttackMax = attackMax;
            BlockMax = blockMax;
        }

        public int Attack()
        {
            Random r = new Random();
            return r.Next(1, AttackMax);
        }
        public int Block()
        {
            Random r = new Random();
            return r.Next(1, BlockMax);
        }

        //metoda asta ar fi trebuit sa fie abstract
        public virtual void SpecialPower() { }
    }
}