using Arenas;
using Characters;
using Fighters;

namespace MainMenu
{
    public class Menu : IMenu
    {
        public void startGame()
        {
            Arena arena = new Arena();

            arena.initializeBattle();
            arena.fightNow(arena.usedCharacters[0], arena.usedCharacters[1]);
        }
    }
}