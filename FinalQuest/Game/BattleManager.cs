using FinalQuest.Characters;
using FinalQuest.Entities;
using FinalQuest.Monsters;
using System;
using System.Numerics;

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
            Console.WriteLine("=== BATTLE MENU ===");
            Console.WriteLine("It's Your Turn, Choose Your Action!");
            Console.WriteLine("1- Attack");
            Console.WriteLine("2- Defend");
            Console.WriteLine("3- Use Skill/Magic");
            Console.WriteLine("4- Use Item");
            Console.WriteLine("5- Flee");
        }

        private void ExecuteAttack(Entity attacker, Entity target)
        {
            int damageDealt = attacker.Attack(target);

            Console.WriteLine($"{attacker.Name} attacks {target.Name}!");
            Console.WriteLine($"> {damageDealt} damage dealt");
            Console.WriteLine();
        }

        private Entity DetermineTurnOrder(Character player, Monster monster)
        {
            if (player.SPD > monster.SPD)
            {
                Console.WriteLine($"{player.Name} Moves First");
                return player;
            }
            if (monster.SPD > player.SPD)
            {
                Console.WriteLine($"{monster.Name} Moves First");
                return monster;
            }
            Random random = new Random();
            int turnRoll = random.Next(0, 2);
            if (turnRoll == 0)
            {
                Console.WriteLine($"{player.Name} Moves First");
                return player;
            }
            Console.WriteLine($"{monster.Name} Moves First");
            return monster;
        }

        private void ShowBattleHeader()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine("                 BATTLE");
            Console.WriteLine(new string('=', 40));
            Console.WriteLine();
        }

        private void HandleVictory(Character player, Monster monster)
        {
            ShowBattleStatus(player, monster);
            Console.WriteLine($"You have defeated the {monster.Name}!");
            Console.WriteLine();
        }

        private void HandleDefeat(Character player, Monster monster)
        {
            ShowBattleStatus(player, monster);
            Console.WriteLine("You Died! Game Over!");
            Console.WriteLine();
        }

        public void StartBattle(Character player, Monster monster)
        {
            Entity firstEntity = DetermineTurnOrder(player, monster);

            while (!player.IsDead && !monster.IsDead)
            {
                ShowBattleStatus(player, monster);

                ShowBattleMenu();

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        ShowBattleHeader();
                        if (firstEntity == player)
                        {
                            ExecuteAttack(player, monster);

                            if (monster.IsDead)
                            {
                                HandleVictory(player, monster);
                                return;
                            }

                            ExecuteAttack(monster, player);

                            if (player.IsDead)
                            {
                                HandleDefeat(player, monster);
                                return;
                            }
                        }
                        else
                        {
                            ExecuteAttack(monster, player);
                            if (player.IsDead)
                            {
                                HandleDefeat(player, monster);
                                return;
                            }

                            ExecuteAttack(player, monster);

                            if (monster.IsDead)
                            {
                                HandleVictory(player, monster);
                                return;
                            }
                        }

                        break;

                    case "2":
                        int originalDEF = player.DEF;
                        player.DEF = (int)(player.DEF * 1.2);

                        ExecuteAttack(monster, player);

                        player.DEF = originalDEF;
                        break;
                }
            }
        }
    }
}