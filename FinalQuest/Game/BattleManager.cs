using FinalQuest.Characters;
using FinalQuest.Entities;
using FinalQuest.Monsters;
using System;

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
            Console.WriteLine($"{attacker.Name} Dealt {damageDealt} to {target.Name}");
        }

        // Determines which entity goes first based on speed (SPD) stat. If both have the same SPD(Speed Tie), it randomly selects one to go first.
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

        public void StartBattle(Character player, Monster monster)
        {
            
            while (player.HP > 0 && monster.HP > 0)
            {
                ShowBattleStatus(player, monster);
                Entity firstEntity = DetermineTurnOrder(player, monster);

                ShowBattleMenu();
                string choice = Console.ReadLine();
                
                
                switch (choice)
                {
                    /*Attack Mechanic
                     * Gestisce attacchi in base alla SPD
                     * Esempio: Player con SPD>, se infligge danno letale non viene attaccato dal mostro
                     */
                    case "1":
                        if (firstEntity == player)
                        {
                            ShowBattleStatus(player, monster);
                            ExecuteAttack(player, monster);

                            if (monster.IsDead)
                            {
                                ShowBattleStatus(player, monster);
                                Console.WriteLine($"You have defeated the {monster.Name}!");
                                Console.WriteLine();
                                return;
                            }

                            ExecuteAttack(monster, player);

                            if (player.IsDead)
                            {
                                Console.WriteLine("You Died! Game Over!");
                                Console.WriteLine();
                                return; 
                            }
                        }
                        else
                        {
                            ShowBattleStatus(player, monster);
                            ExecuteAttack(monster, player);
                            if (player.IsDead)
                            {
                                Console.WriteLine("You Died! Game Over!");
                                Console.WriteLine();
                                return;
                            }

                            ExecuteAttack(player, monster);

                            if (monster.IsDead)
                            {
                                ShowBattleStatus(player, monster);
                                Console.WriteLine($"You have defeated the {monster.Name}!");
                                Console.WriteLine();
                                return;
                            }
                        }
                        break;

                    //case "2":
                    //    int originalDEF = player.DEF;
                    //    player.DEF = (int)(player.DEF * 1.2);
                    //    monster.Attack(player);
                    //    player.DEF = originalDEF;
                    //    break;
                    }
                }
            } 
        }
    }
