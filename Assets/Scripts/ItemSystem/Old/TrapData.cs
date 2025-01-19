using UnityEngine;
using Unity.Netcode; // Requires Unity Netcode for multiplayer

namespace ItemSystem
{
    
    [CreateAssetMenu(fileName = "TrapBehavior", menuName = "Item System/Behaviors/Trap")]
    public class TrapData : ItemData
    {
        public GameObject TrapPrefab;
        public Vector3 SpawnOffset;

        public override void Execute(GameObject user)
        {
            NetworkObject networkObject = user.GetComponent<NetworkObject>();
            
            // if(networkObject == null)
            // {
            //     ulong clientId = networkObject.OwnerClientId;
            //     
            //     Vector3 spawnPosition = user.transform.position + SpawnOffset;
            //
            //     FindFirstObjectByType<PlayerNetworkController>().RequestTrapSpawn(spawnPosition, clientId);
            // }
        
            ulong clientId = networkObject.OwnerClientId;
                
            Vector3 spawnPosition = user.transform.position + SpawnOffset;
            
            FindFirstObjectByType<PlayerNetworkController>().RequestTrapSpawn(spawnPosition, clientId);
            
            
            
            
        }
        
    }
    
}