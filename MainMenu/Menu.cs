using Arenas;

namespace MainMenu
{
    public class Menu : IMenu
    {
        public void StartGame()
        {
            Arena arena = new Arena();

            arena.InitializeBattle();
            // primul caracter incepe mereu lupta si are sanse mai mari de castig
            arena.FightNow(arena.UsedCharacters[0], arena.UsedCharacters[1]);
        }
    }
}