using System;

namespace AsylumEscape
{
    class Game
    {
        #region Fields
        private Player player;
        private Map map;
        #endregion

        #region Constructor
        public Game()
        {
            player = new Player();
            map = new Map();
        }
        #endregion

        #region Methods
        public void Start()
        {
            Console.WriteLine("Welcome to Asylum Escape!");
            Console.Write("Please enter your name: ");
            string playerName = Console.ReadLine();

            Console.WriteLine($"\n{playerName}, it's midnight... The asylum corridors are silent and dark.");
            Console.WriteLine("The guards are on a break for one hour, and there's no one around.");
            Console.WriteLine("This might be your only chance to escape.");
            Console.WriteLine("However, you must be careful; every step and decision matters.");
            Console.WriteLine("If you make the right choices, you might escape this darkness.");
            Console.WriteLine("Are you ready? Let's begin!\n");

            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Credits");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                NewGame();
            }
            else if (choice == "2")
            {
                ShowCredits();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Start();
            }
        }

        private void NewGame()
        {
            Console.WriteLine("\nStarting the game...");
            map.Explore(player);
        }

        private void ShowCredits()
        {
            Console.WriteLine("\nCredits:");
            Console.WriteLine("Game Design: [Ahmet Ali Kayaci]");
            Console.WriteLine("Programming: [Ahmet Ali Kayaci]");
            Start();
        }
        #endregion
    }
}
