using UnityEngine;
using UnityEngine.Serialization;

namespace ItemSystem
{
    [CreateAssetMenu( menuName = "Inventory/Item", fileName = "NewItem")]
    public class ItemData : ScriptableObject
    {
        public string ItemName;
        public string Description;
        public Sprite Icon;
        public GameObject Prefab;
        
        public virtual void Use(GameObject player)
        {
                Debug.Log("Using " + ItemName);
        }
    }
}
