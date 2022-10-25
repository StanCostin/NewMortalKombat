using Characters;
using Fighters;
using Mages;
using Warriors;

namespace Arenas
{
    public class Arena
    {
        private List <Character> allCharacters;
        public List <Character> usedCharacters { set; get; }

        public Arena()
        {
            allCharacters = new List<Character>();
            usedCharacters = new List<Character>();
        }
        
        public void appendCharacter(Character C)
        {
            allCharacters.Add(C);
        }
        
        public void getall_charactersFromFile()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fileName = projectDirectory + "\\Characters.txt";
            string[] lines = System.IO.File.ReadAllLines(fileName);
            string name; string attribute;
            foreach (string line in lines)
            {
                name = line.Split(" ")[0];
                attribute = line.Split(" ")[1];
                Character C = null;
                switch (attribute[0])
                {
                    case 'F':
                        C = new Fighter(name, 100, attribute[0], Int32.Parse(line.Split(" ")[2]), Int32.Parse(line.Split(" ")[3]), Int32.Parse(line.Split(" ")[4]));
                        break;
                    case 'M':
                        C = new Mage(name, 100, attribute[0], Int32.Parse(line.Split(" ")[2]), Int32.Parse(line.Split(" ")[3]), Int32.Parse(line.Split(" ")[4]));
                        break;
                    case 'W':
                        C = new Warrior(name, 100, attribute[0], Int32.Parse(line.Split(" ")[2]), Int32.Parse(line.Split(" ")[3]), Int32.Parse(line.Split(" ")[4]));
                        break;
                    default:
                        break;
                }
                appendCharacter(C);
            }

        }

        public void selectall_characters()
        {
            Console.WriteLine("Jocul de mortal kombat incepe...Alegeti-va caracterele din urmatoarea lista:");
            foreach (Character c in allCharacters)
            {
                switch (c.Atribute)
                {
                    case 'F':
                        Console.WriteLine(c.Name + " FIGHTER");
                        break;
                    case 'M':
                        Console.WriteLine(c.Name + " MAGE");
                        break;
                    case 'W':
                        Console.WriteLine(c.Name + " WARRIOR");
                        break;
                    default:
                        break;
                }
            }
            string ch1, ch2;
            ch1 = Console.ReadLine();
            ch2 = Console.ReadLine();

            foreach (Character c in allCharacters)
            {
                if (c.Name.Equals(ch1)|| c.Name.Equals(ch2))
                    usedCharacters.Add(c);
            }
            if (usedCharacters.Count != 2)
                throw new Exception("Nu s-au ales exact doua caractere valide!");
         
        }

        public void initializeBattle()
        {
            getall_charactersFromFile();
            selectall_characters();
        }

        public void fightNow (Character character1, Character character2)
        {
            while (true)
            {
                if (GetAttackResult(character1, character2) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    break;
                }

                if (GetAttackResult(character2, character1) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    break;
                }
            }
        }

        public static string GetAttackResult(Character character1, Character character2)
        {
            int damageValue = character1.Attack() - character2.Block();

            if (damageValue > 0)
            {
                character2.Health = character2.Health - damageValue;
            }
            else damageValue = 0;

            switch (character1.Atribute)
            {
                case 'F':
                    character2.specialPower();
                    break;     
                case 'M':
                    character1.specialPower();
                    break;   
                case 'W':
                    character1.specialPower();
                    break;
                default:
                    break;

            }

            Console.WriteLine("{0} Ataca {1} si da {2} Damage",
                character1.Name + " "+ character1.Atribute,
                character2.Name + " "+character2.Atribute,
                damageValue);

            Console.WriteLine("{0} are {1} HP\n",
                character2.Name + " " + character2.Atribute,
                character2.Health);

            if (character2.Health <= 0)
            {
                Console.WriteLine("{0} a murit si {1} este victorios\n",
                        character2.Name + " " + character2.Atribute,
                        character1.Name + " " + character1.Atribute);

                return "Game Over";
            }
            else return "Fight Again";
        }
    }
}