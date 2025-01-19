using System;
using UnityEngine;


namespace ItemSystem
{
    [Serializable]
    public class ItemTest 
    {
        public string ItemID { get; private set; }
        public string ItemName { get; private set; }
        public Sprite Icon { get; private set; }
        public string Description { get; private set; }
        public int StackCount { get; set; }
        
        private ItemData _data;
        public ItemTest(string itemID, string itemName, Sprite icon, string description, ItemData data, int initialStack = 1)
        {
            ItemID = itemID;
            ItemName = itemName;
            Icon = icon;
            Description = description;
            this._data = data;
            StackCount = Mathf.Max(1, initialStack); // Ensure at least 1 stack
        }

        public void Use(GameObject user)
        {
            if (_data != null)
            {
                _data.Execute(user); // Delegate action to the behavior
                StackCount--; // Decrease stack count after use
            }
        }
    }
}
