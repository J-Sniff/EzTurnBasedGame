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
            int playerHp = 100;
            int enemyHp = 50;

            int playerAttack = 13;
            int enemyAttack = 18;

            int playerHeal = 15;
            int enemyHeal = 6;

            Random random = new Random();

            while(playerHp > 0 && enemyHp > 0)
            {
                Console.WriteLine("------*------ Player Turn ------*------");
                Console.WriteLine($"Player HP - {playerHp} [{GetHealthBar(playerHp)}]");
                Console.WriteLine($"Enemy HP - {enemyHp} [{GetHealthBar(enemyHp)}]");
                Console.WriteLine("Enter 'A' to attack or 'H' to heal.");

                string choice = Console.ReadLine();
                string playerChoice = choice.ToUpper();
                
                // Player turn
                if(playerChoice == "A")
                {
                    enemyHp -= playerAttack;
                    Console.WriteLine($"Player attacks the enemy and deals {playerAttack} damage!");
                } 
                else if(playerChoice == "H")
                {
                    playerHp += playerHeal;
                    Console.WriteLine($"Player has healed for {playerHeal} HP.");
                }
                else
                {
                    Console.WriteLine("Invalid key Please enter 'A' to attack or 'H' to heal.");
                    continue;
                }

                // Enemy turn
                if(enemyHp > 0)
                {
                    Console.WriteLine("------*------ Enemy Turn ------*------");
                    Console.WriteLine($"Player HP - {playerHp} [{GetHealthBar(playerHp)}]");
                    Console.WriteLine($"Enemy HP - {enemyHp} [{GetHealthBar(enemyHp)}]");
                    int enemyChoice = random.Next(0, 2);

                    if(enemyChoice == 0)
                    {
                        playerHp -= enemyAttack;
                        Console.WriteLine($"Enemy has attacked the player for {enemyAttack} damage!");
                    }
                    else
                    {
                        enemyHp += enemyHeal;
                        Console.WriteLine($"Enemy has healed themself for {enemyHeal} HP.");
                    }
                }
            }
            
            if(playerHp > 0)
            {
                Console.WriteLine("*****YOU HAVE DEFEATED THE ENEMY!!*****");
            }
            else
            {
                Console.WriteLine("You have been defeated RIP..");
            }
            Console.ReadLine();
        }

        static string GetHealthBar(int health)
        {
            int maxHealth = 100; // Assuming max health is 100
            int barLength = 20;  // Length of the health bar

            int filledLength = (int)Math.Ceiling((double)health / maxHealth * barLength);
            int emptyLength = barLength - filledLength;

            string healthBar = new string('#', filledLength) + new string('-', emptyLength);
            return $"[{healthBar}]";
        }
    }
}
