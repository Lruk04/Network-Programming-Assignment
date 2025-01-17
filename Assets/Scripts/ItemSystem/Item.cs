using System;
using UnityEngine;

namespace ItemSystem
{
    [Serializable]
    public abstract class Item 
    {
        public string ItemName;
        public string Description;
        public int ItemCount;
        
        public Sprite Icon;
        public GameObject Prefab;
        public ItemData ItemData;
        
        
        public Item(ItemData itemData)
        {
            ItemName = itemData.ItemName;
            Description = itemData.Description;
            ItemCount = itemData.ItemCount;
            Icon = itemData.Icon;
            Prefab = itemData.Prefab;
            
            ItemData = itemData;
        }
        
        public virtual void Use(GameObject player)
        {
            Debug.Log("Using " + ItemName);
            
        }
        
    }
}
