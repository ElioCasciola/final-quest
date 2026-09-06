using FinalQuest.Characters;
using FinalQuest.Monsters;
using FinalQuest.Game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace FinalQuest.Game
{
    internal class GameManager
    {
        public void Start()
        {
            Console.WriteLine("=== FINAL QUEST ===");
            Console.WriteLine("What's your name?");
            string name = Console.ReadLine();
            Console.WriteLine();
            Character? player = null;
            bool classSelected = false;

            while (!classSelected)
            {
                Console.WriteLine("Choose your class:");
                Console.WriteLine("1 - Warrior");
                Console.WriteLine("2 - Mage");
                Console.WriteLine("3 - Rogue");
                string choice = Console.ReadLine();
                Console.WriteLine();


                switch (choice)
                {
                    case "1":
                        player = new Warrior(name);
                        classSelected = true;
                        break;
                    case "2":
                        player = new Mage(name);
                        classSelected = true;
                        break;
                    case "3":
                        player = new Rogue(name);
                        classSelected = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }

            
            bool gameRunning = true;
                while (gameRunning)
                {
                    Console.WriteLine("=== What do you want to do? ===");
                    Console.WriteLine("1 - Explore");
                    Console.WriteLine("2 - Check stats");
                    Console.WriteLine("3 - Exit");
                    string action = Console.ReadLine();
                    Console.WriteLine();
                    switch (action)
                    {
                        case "1":
                            Explore(player);
                            break;
                        case "2":
                            player.ShowStats();
                            break;
                        case "3":
                            Console.WriteLine("Goodbye!");
                            gameRunning = false;
                            break;
                        default:
                        Console.WriteLine("Invalid Choice, Try Again");
                        break;

                    }
                }
        }

        private void Explore(Character player)
        {
            Random random = new Random();
            int result = random.Next(1, 4);
            switch(result)
            {
                case 1:
                    Console.WriteLine("You Found Nothing!");
                    break;
                case 2:
                    Console.WriteLine("You Found A Treasure!");
                    break;
                case 3:
                    Console.WriteLine("A Monster Appears!");
                    Monster goblin = new Goblin();
                    BattleManager battleManager = new BattleManager();
                    battleManager.StartBattle(player, goblin);
                    break;
            }
        }
    }
}
