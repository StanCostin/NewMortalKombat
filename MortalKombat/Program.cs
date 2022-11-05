using MainMenu;

namespace MortalKombat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // lipseste global exeption handler
            // lipsesc unit testele
            // e greu de determinat daca eroii sunt balansati
            // implementarile functionalitatilor sunt minimaliste
            // pe git ai pus tot...
            try
            {
                IMenu menu = new Menu();
                menu.StartGame();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}