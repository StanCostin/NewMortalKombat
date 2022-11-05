using Arenas;

namespace MainMenu
{
    public class Menu : IMenu
    {
        public void startGame()
        {
            Arena arena = new Arena();

            arena.InitializeBattle();
            arena.FightNow(arena.usedCharacters[0], arena.usedCharacters[1]);
        }
    }
}