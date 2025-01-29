namespace AsylumEscape
{
    class Player
    {
        #region Properties
        public Inventory Inventory { get; set; }
        #endregion

        #region Constructor
        public Player()
        {
            Inventory = new Inventory();
        }
        #endregion
    }
}