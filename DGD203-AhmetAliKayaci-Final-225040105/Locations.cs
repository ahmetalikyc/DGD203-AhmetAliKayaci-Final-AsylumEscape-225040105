namespace AsylumEscape
{
    class Locations
    {
        #region Map Data
        public static string[,] MapData { get; } = new string[3, 3]
        {
            { "Cell", "Corridor", "Wall" },
            { "Storage Room", "Garden", "Security Room" },
            { "Wall", "Wall", "Exit" }
        };
        #endregion

        #region Methods
        public static string[] GetAvailableDirections(int x, int y)
        {
            List<string> directions = new List<string>(); 
            if (y > 0 && MapData[x, y - 1] != "Wall") 
                directions.Add("Left: Go left (" + MapData[x, y - 1] + ")");
            if (y < 2 && MapData[x, y + 1] != "Wall") 
                directions.Add("Right: Go right (" + MapData[x, y + 1] + ")");
            if (x > 0 && MapData[x - 1, y] != "Wall") 
                directions.Add("Up: Go up (" + MapData[x - 1, y] + ")");
            if (x < 2 && MapData[x + 1, y] != "Wall") 
                directions.Add("Down: Go down (" + MapData[x + 1, y] + ")");
            return directions.ToArray(); 
        }

        #endregion
    }
}