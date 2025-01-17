using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
    public class InventorySystem : MonoBehaviour
    {
        [SerializeField] private List<ItemData> _items = new List<ItemData>();
   
        [SerializeField] private List<Item> _itemList = new List<Item>();
        
        private int _selectedItem = 0;

        private void Start()
        {
            _items.Add(null);
            _items.Add(null);
       
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CycleItem();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                DiscardSelectedItem();
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                UseItem(_selectedItem);
            }
        }
        public void AddItemToinventory(ItemData itemData, int slot)
        {
            if (slot == 1)
            {
                _items[0] = itemData;
            }
            else if (slot == 2)
            {
                _items[1] = itemData;
            }
        }
   
        private void UseItem(int slot)
        {
            if(_items[slot] == null) return;
      
            _items[slot].Use(this.gameObject);


            switch (_items[slot].ItemType)
            {
                case ItemData.Type.Consumable:
                    
                    break;
                case ItemData.Type.Trap:
                    
                    break;
                case ItemData.Type.Weapon:
                    
                    
                    break;
            }
            {
                
            }
            
            
        }
   
        private void DiscardSelectedItem()
        {
            _items[_selectedItem] = null;
        }

        private void CycleItem()
        {
            _selectedItem = (_selectedItem + 1) % _items.Count;
        }
   
   
   
   
   
   
    }
}
