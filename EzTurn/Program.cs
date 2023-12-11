using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzTurn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Player and Enemy variables
            int heroHp = 100;
            int enemy1Hp = 50;
            int enemy2Hp = 50;

            int heroAttack = 13;
            int enemy1Attack = 20;
            int enemy2Attack = 18;

            int heroHeal = 15;
            int enemy1Heal = 6;
            int enemy2Heal = 6;

            Random random = new Random();

            while(heroHp > 0 && (enemy1Hp > 0 || enemy2Hp > 0))
            {
                Console.WriteLine("------*------ Hero Turn ------*------");
                Console.WriteLine($"Hero HP - {heroHp}");
                Console.WriteLine($"Enemy1 HP - {enemy1Hp}");
                Console.WriteLine($"Enemy2 HP - {enemy2Hp}");
                //Console.WriteLine($"Hero HP - {heroHp} [{GetHealthBar(heroHp)}]");            // disabled health bar until redesigned
                //Console.WriteLine($"Enemy1 HP - {enemy1Hp} [{GetHealthBar(enemy1Hp)}]");      // disabled health bar until redesigned
                Console.WriteLine("Enter 'A' to attack or 'H' to heal.");


                string choice = Console.ReadLine();
                string playerChoice = choice.ToUpper();
                
                
                // Player turn
                if(playerChoice == "A")
                {
                    Console.WriteLine("Choose the enemy you would like to attack (1 or 2):");
                    int targetEnemy;

                    // Choosing between enemies
                    if (int.TryParse(Console.ReadLine(), out targetEnemy) && (targetEnemy == 1 || targetEnemy == 2))
                    {
                        if (targetEnemy == 1)
                        {
                            enemy1Hp -= heroAttack;  
                            Console.WriteLine($"Player attacks Enemy1 and deals {heroAttack} damage!");
                        }
                        else
                        {
                            enemy2Hp -= heroAttack;
                            Console.WriteLine($"Player attacks Enemy2 and deals {heroAttack} damage!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid target. Please enter 1 to attack enemy1 or 2 to attack enemy2");
                        continue;
                    }
                } 
                else if(playerChoice == "H")
                {
                    heroHp += heroHeal;
                    Console.WriteLine($"Player has healed for {heroHeal} HP.");
                }
                else
                {
                    Console.WriteLine("Invalid key Please enter 'A' to attack or 'H' to heal.");
                    continue;
                }

                // Enemy turn
                if(enemy1Hp > 0)
                {
                    Console.WriteLine("------*------ Enemy Turn ------*------");
                    Console.WriteLine($"Hero HP - {heroHp}");
                    Console.WriteLine($"Enemy1 HP - {enemy1Hp}");
                    //Console.WriteLine($"Hero HP - {heroHp} [{GetHealthBar(heroHp)}]");            // disabled health bar until redesigned
                    //Console.WriteLine($"Enemy1 HP - {enemy1Hp} [{GetHealthBar(enemy1Hp)}]");      // disabled health bar until redesigned
                    int enemyChoice = random.Next(0, 2);

                    if(enemyChoice == 0)
                    {
                        heroHp -= enemy1Attack;
                        Console.WriteLine($"Enemy has attacked the player for {enemy1Attack} damage!");
                    }
                    else
                    {
                        enemy1Hp += enemy1Heal;
                        Console.WriteLine($"Enemy has healed themself for {enemy1Heal} HP.");
                    }
                }
            }
            
            if(heroHp > 0)
            {
                Console.WriteLine("***************************************");
                Console.WriteLine("*****YOU HAVE DEFEATED THE ENEMY!!*****");
                Console.WriteLine("***************************************");
            }
            else
            {
                Console.WriteLine("**********************************************");
                Console.WriteLine("***** -RIP- YOU HAVE BEEN DEFEATED -RIP- *****");
                Console.WriteLine("**********************************************");
            }
            Console.ReadLine();
        }


        //=========== Implemented health bar needs to be redesigned ===============================================

        //static string GetHealthBar(int health)
        //{
        //    int maxHealth = 100; // Assuming max health is 100
        //    int barLength = 20;  // Length of the health bar

        //    int filledLength = (int)Math.Ceiling((double)health / maxHealth * barLength);
        //    int emptyLength = barLength - filledLength;

        //    string healthBar = new string('#', filledLength) + new string('-', emptyLength);
        //    return $"[{healthBar}]";
        //}
    }
}
