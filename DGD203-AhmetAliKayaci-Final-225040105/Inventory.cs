using System;
using System.Collections.Generic;

namespace AsylumEscape
{
    class Inventory
    {
        #region Fields
        private List<string> items;
        #endregion

        #region Constructor
        public Inventory()
        {
            items = new List<string>();
        }
        #endregion

        #region Methods
        public void AddItem(string item)
        {
            items.Add(item);
            Console.Write($"{item} has been added to your inventory.");
        }

        public bool Contains(string item)
        {
            return items.Contains(item);
        }
        #endregion
    }
}