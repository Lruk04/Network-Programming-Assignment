using UnityEngine;

namespace ItemSystem
{
    public abstract class ItemData : ScriptableObject
    {
        public string DisplayName;
        public Sprite Icon;
        public string Description;

        public abstract void Execute(GameObject user);
    }
    
}
