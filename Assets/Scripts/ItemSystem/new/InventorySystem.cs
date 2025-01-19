using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace ItemSystem
{
    public class InventorySystem : NetworkBehaviour
    {
        [SerializeField] private List<ItemData> _items = new List<ItemData>();
        
        
        private int _selectedItem = 0;

        private void Start()
        {
            _items.Add(null);
            _items.Add(null);
       
        }

        private void Update()
        {
            if(!IsOwner) return;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CycleItem();
            }
            // else if (Input.GetKeyDown(KeyCode.E))
            // {
            //     DiscardSelectedItem();
            // }
            else if (Input.GetKeyDown(KeyCode.R))
            {
              
                UseItem(_selectedItem);
            }
        }
        public void AddItemToinventory(ItemData itemDataOld, int slot)
        {
            if (slot == 1)
            {
                _items[0] = itemDataOld;
            }
            else if (slot == 2)
            {
                _items[1] = itemDataOld;
            }
        }
   
        private void UseItem(int slot)
        {
            if(_items[slot] == null) return;
      
            _items[slot].Execute(this.gameObject);


            // switch (_items[slot].ItemType)
            // {
            //     case ItemDataOld.Type.Consumable:
            //         
            //         break;
            //     case ItemDataOld.Type.Trap:
            //         
            //         break;
            //     case ItemDataOld.Type.Weapon:
            //         
            //         
            //         break;
            // }
          
            
            
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
