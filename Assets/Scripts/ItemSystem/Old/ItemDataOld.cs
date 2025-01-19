using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;

namespace ItemSystem
{
    [CreateAssetMenu( menuName = "Inventory/Item", fileName = "NewItem")]
    public class ItemDataOld : ScriptableObject
    {
        public string ItemName;
        public string Description;
        public int ItemCount;
        
        public Sprite Icon;
        public GameObject Prefab;
        
        public enum Type
        {
            Consumable,
            Trap,
            Weapon
        }
        
        public Type ItemType;
        
        
        public virtual void Use(GameObject player)
        {
                Debug.Log("Using " + ItemName);
        }
    }
}
