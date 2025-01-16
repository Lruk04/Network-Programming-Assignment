using Unity.Netcode;
using UnityEngine;

namespace ItemSystem
{
    public abstract class  BaseTrapBehaviour : NetworkBehaviour
    {
        public GameObject Owner { get; set; }
        public string TrapName { get; set; }

        public abstract void TriggerTrap();
    }
}