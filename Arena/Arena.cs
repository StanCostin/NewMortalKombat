using Characters;
using Fighters;
using Mages;
using Warriors;

namespace Arenas
{
    public class Arena
    {
        private List <Character> allCharacters;

        //proprietatile se scriu cu litera mare
        public List <Character> UsedCharacters { set; get; }

        public Arena()
        {
            allCharacters = new List<Character>();
            UsedCharacters = new List<Character>();
        }
        
        //denumirea parametrilor trebuie sa fie sugestiva
        //nu are nici un sens ca aceasta metoda sa fie publica
        private void AppendCharacter(Character character)
        {
            allCharacters.Add(character);
        }
        
        //_ nu are ce cauta in denumirea metodelor
        public void GetallCharactersFromFile()
        {
            string workingDirectory = Environment.CurrentDirectory;
            //GetParent(...).Parent.Parent n-o sa mearga in productie
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fileName = projectDirectory + "\\Characters.txt";
            //citirea din fisier fara try...catch e sinucidere :)
            string[] lines = File.ReadAllLines(fileName);
            string name; 
            string attribute;
            foreach (string line in lines)
            {
                name = line.Split(" ")[0];
                attribute = line.Split(" ")[1];
                Character character = null;
                switch (attribute[0])
                {
                    case 'F':
                        character = new Fighter(name, 100, attribute[0], Int32.Parse(line.Split(" ")[2]), Int32.Parse(line.Split(" ")[3]), Int32.Parse(line.Split(" ")[4]));
                        break;
                    case 'M':
                        character = new Mage(name, 100, attribute[0], Int32.Parse(line.Split(" ")[2]), Int32.Parse(line.Split(" ")[3]), Int32.Parse(line.Split(" ")[4]));
                        break;
                    case 'W':
                        character = new Warrior(name, 100, attribute[0], Int32.Parse(line.Split(" ")[2]), Int32.Parse(line.Split(" ")[3]), Int32.Parse(line.Split(" ")[4]));
                        break;
                    default:
                        break;
                }
                AppendCharacter(character);
            }

        }

        // metoda e publica fara rost
        //denumirea nu respecta nici un standard
        private void SelectAllCharacters()
        {
            Console.WriteLine("Jocul de mortal kombat incepe...Alegeti-va caracterele din urmatoarea lista:");
            // variabila c face codul greu de citit
            foreach (Character character in allCharacters)
            {
                switch (character.Atribute)
                {
                    case 'F':
                        Console.WriteLine(character.Name + " FIGHTER");
                        break;
                    case 'M':
                        Console.WriteLine(character.Name + " MAGE");
                        break;
                    case 'W':
                        Console.WriteLine(character.Name + " WARRIOR");
                        break;
                    default:
                        break;
                }
            }
            //ch1? ch2?
            string? ch1, ch2;
            Console.WriteLine("Este randul jucatorului 1 sa aleaga caracterul din lista de mai sus:");
            ch1 = Console.ReadLine();
            Console.WriteLine("Este randul jucatorului 2 sa aleaga caracterul din lista de mai sus:");
            ch2 = Console.ReadLine();

            // c?
            foreach (Character c in allCharacters)
            {
                if (c.Name.Equals(ch1)|| c.Name.Equals(ch2))
                    UsedCharacters.Add(c);
            }
            if (UsedCharacters.Count != 2)
                throw new InvalidOperationException("Nu s-au ales exact doua caractere valide!");
         
        }

        public void InitializeBattle()
        {
            GetallCharactersFromFile();
            SelectAllCharacters();
        }

        public void FightNow (Character character1, Character character2)
        {
            //character1 sau character2 ar putea fi null
            if (character1 is null)
            {
                throw new ArgumentNullException(nameof(character1));
            }
            if (character2 is null)
            {
                throw new ArgumentNullException(nameof(character2));
            }

            //risc de infinite loop
            while (true)
            {
                // ar fi fost mai intelept ca metoda GetAttackResult
                // sa intoarca un bool si sa fie folosita in while
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
                    // nu inteleg de ce switch-ul e pe character1 si speciala e 
                    // pe character2
                    character2.SpecialPower();
                    break;     
                case 'M':
                case 'W':
                    //simplificam codul
                    character1.SpecialPower();
                    break;
                default:
                    break;

            }

            Console.WriteLine("{0} Ataca {1} si da {2} Damage",
                character1.Name + " " + character1.Atribute,
                character2.Name + " " + character2.Atribute,
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
            else 
                //bool s-au enum sunt de preferat ca return in loc de string
                return "Fight Again";
        }
    }
}