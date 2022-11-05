using MainMenu;

namespace MortalKombat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IMenu menu = new Menu();
                menu.startGame();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}