using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
    public class Inventory : MonoBehaviour
    {
        public List<ItemData> Items = new List<ItemData>();

        // private void Update()
        // {
        //
        //     if (Input.GetKeyDown(KeyCode.E))
        //     {
        //         UseItem("TrapBehavior", gameObject);
        //     }
        // }
        // public void AddItem(Item item)
        // {
        //     Item existingItem = Items.Find(i => i.ItemID == item.ItemID);
        //     if (existingItem != null)
        //     {
        //         existingItem.StackCount += item.StackCount;
        //     }
        //     else
        //     {
        //         Items.Add(item);
        //     }
        // }
        //
        // public void UseItem(string itemID, GameObject user)
        // {
        //     Item item = Items.Find(i => i.ItemID == itemID);
        //     if (item != null)
        //     {
        //         item.Use(user);
        //         if (item.StackCount <= 0)
        //         {
        //             Items.Remove(item);
        //         }
        //     }
        // }
    }
}
