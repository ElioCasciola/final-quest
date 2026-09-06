using FinalQuest.Characters;
using FinalQuest.Game;

namespace FinalQuest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager launch = new GameManager();
            launch.Start();
        }
    }
}
