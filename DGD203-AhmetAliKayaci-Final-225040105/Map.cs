using System;

namespace AsylumEscape
{
    class Map
    {
        #region Methods
        public void Explore(Player player)
        {
            int x = 0, y = 0;
            while (true)
            {
                Console.WriteLine($"\nYour current location: {Locations.MapData[x, y]}");
                ShowLocationMessage(Locations.MapData[x, y]); 

                string[] directions = Locations.GetAvailableDirections(x, y);
                Console.WriteLine("Where would you like to go?");
                foreach (var direction in directions)
                {
                    Console.WriteLine($"- {direction}");
                }

                string choice = Console.ReadLine().Trim().ToLower();
                string selectedDirection = GetDirectionFromChoice(choice);

                if (selectedDirection == "Left" && y > 0) y--;
                else if (selectedDirection == "Right" && y < 2) y++;
                else if (selectedDirection == "Up" && x > 0) x--;
                else if (selectedDirection == "Down" && x < 2) x++;
                else
                {
                    Console.WriteLine("Invalid direction. Please enter 'left', 'right', 'up', or 'down'.");
                    continue;
                }

                if (Locations.MapData[x, y] == "Exit")
                {
                    Console.WriteLine("\nCongratulations! You have successfully escaped the asylum!");
                    break;
                }

                if (Locations.MapData[x, y] == "Security Room" && !player.Inventory.Contains("Key"))
                {
                    Console.WriteLine("\nYou need a key to enter the security room!");
                    Console.WriteLine("Press any key to go back...");
                    Console.ReadKey();
                    x = 1; y = 1; // Return to Garden
                }
                else if (Locations.MapData[x, y] == "Security Room" && player.Inventory.Contains("Key"))
                {
                    Console.WriteLine("You used the key to enter the security room and unlocked the exit door!");
                    player.Inventory.AddItem("Exit Key");
                }

                if (Locations.MapData[x, y] == "Storage Room" && !player.Inventory.Contains("Key"))
                {
                    Console.WriteLine("You found a key in the storage room!");
                    player.Inventory.AddItem("Key");
                }
            }
        }

        private string GetDirectionFromChoice(string choice)
        {
            if (choice.Contains("left")) return "Left";
            if (choice.Contains("right")) return "Right";
            if (choice.Contains("up")) return "Up";
            if (choice.Contains("down")) return "Down";
            return "";
        }

        private void ShowLocationMessage(string location)
        {
            switch (location)
            {
                case "Cell":
                    Console.WriteLine("You wake up in your cold and dark cell. The air smells of dampness.");
                    break;
                case "Corridor":
                    Console.WriteLine("The dimly lit corridor stretches in both directions. You hear distant whispers.");
                    break;
                case "Storage Room":
                    Console.WriteLine("You see shelves filled with old tools and supplies.");
                    Console.WriteLine("Among the items, you notice a small key on the shelf and you took!");
                    break;
                case "Garden":
                    Console.WriteLine("You take a deep breath. The fresh air clears your mind.");
                    break;
                case "Security Room":
                    Console.WriteLine("You see multiple monitors displaying asylum corridors.");
                    break;
                case "Exit":
                    Console.WriteLine("A heavy metal door stands before you. Your escape is near!");
                    break;
                default:
                    Console.WriteLine("You stand in an unknown place. Be cautious.");
                    break;
            }
        }

        #endregion
    }
}