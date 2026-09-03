using FinalQuest.Characters;
using FinalQuest.Entities;
using FinalQuest.Monsters;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace FinalQuest.Game
{
    internal class BattleManager
    {
        private void ShowBattleStatus(Character player, Monster monster)
        {
            Console.WriteLine("=== BATTLE STATUS ===");
            Console.WriteLine();
            Console.WriteLine(player.Name);
            Console.WriteLine(player.Job);
            Console.WriteLine($"HP: {player.HP}/{player.MaxHP}");
            Console.WriteLine($"MP: {player.MP}/{player.MaxMP}");
            Console.WriteLine($"ATT: {player.ATT}");
            Console.WriteLine($"DEF: {player.DEF}");
            Console.WriteLine($"SPD: {player.SPD}");
            Console.WriteLine();
            Console.WriteLine(monster.Name);
            Console.WriteLine($"HP: {monster.HP}/{monster.MaxHP}");
            Console.WriteLine($"MP: {monster.MP}/{monster.MaxMP}");
            Console.WriteLine($"ATT: {monster.ATT}");
            Console.WriteLine($"DEF: {monster.DEF}");
            Console.WriteLine($"SPD: {monster.SPD}");
            Console.WriteLine();
        }

        private void ShowBattleMenu()
        {
            Console.WriteLine("=== BATTLE MENU===");
            Console.WriteLine("It's Your Turn, Choose Your Action!");
            Console.WriteLine("1- Attack");
            Console.WriteLine("2- Defend");
            Console.WriteLine("3- Use Skill/Magic");
            Console.WriteLine("4- Use Item");
            Console.WriteLine("5- Flee");
        }
        public void StartBattle(Character player, Monster monster)
        {
            bool battleRunning = true;
            ShowBattleStatus(player, monster);

            Entity firstEntity;
            Entity secondEntity;

            if (player.SPD > monster.SPD)
            {
                Console.WriteLine($"{player.Name} Moves First");
                firstEntity = player;
                secondEntity = monster;

            }
            else if (player.SPD < monster.SPD)
            {
                Console.WriteLine($"{monster.Name} Moves First");
                firstEntity = monster;
                secondEntity = player;
            }
            else
            {
                Random random = new Random();
                int first = random.Next(0, 2);
                if (first == 0)
                {
                    Console.WriteLine($"{player.Name} Moves First");
                    firstEntity = player;
                    secondEntity = monster;
                }
                else
                {
                    Console.WriteLine($"{monster.Name} Moves First");
                    firstEntity = monster;
                    secondEntity = player;
                }
            }

            while (player.HP >= 0 && monster.HP >= 0)
            {
                ShowBattleStatus(player, monster);
                ShowBattleMenu();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        player.Attack(monster);
                        monster.Attack(player);
                        break;
                    case "2":
                        bool isDefending = true;
                        int originalDEF = player.DEF;
                        player.DEF = (int)(player.DEF * 1.2);
                        monster.Attack(player);
                        player.DEF = originalDEF;
                        break;
                }
                ShowBattleStatus(player, monster);
            }
        }
    }
}

