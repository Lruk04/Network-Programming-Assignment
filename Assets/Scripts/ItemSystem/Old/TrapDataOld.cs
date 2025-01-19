using Unity.Netcode;
using UnityEngine;
using Unity.Netcode;

namespace ItemSystem
{
    [CreateAssetMenu( menuName = "Inventory/Item/Traps", fileName = "TrapItem")]
    public class TrapDataOld : ItemDataOld
    {
        public GameObject TrapPrefab;

        
       
    
        public override void Use(GameObject player)
        {
            base.Use(player);
        
            PlaceTrap(player);
            // PlaceTrapServerRpc(player.GetComponent<NetworkObject>());
        }
        // [ServerRpc]
        // public void PlaceTrapServerRpc(NetworkObjectReference playerref)
        // {
        //     if(playerref.TryGet(out NetworkObject playerObject))
        //     {
        //         PlaceTrap(playerObject.gameObject);
        //     }
        // }
        //
        public void PlaceTrap(GameObject player)
        {
            if(TrapPrefab != null)
            {
                Vector3 spawnPosition = player.transform.position + player.transform.up;

                //NetworkItemSpawner.Instance.SpawnItemServerRpc(TrapPrefab, spawnPosition, Quaternion.identity, player);
                
                
                // GameObject trapInstance = Object.Instantiate(TrapPrefab, spawnPosition, Quaternion.identity);
                //
                // NetworkObject networkObject = trapInstance.GetComponent<NetworkObject>();
                //
                // networkObject.Spawn();
                

                Debug.Log($"{ItemName} placed at {spawnPosition} by {player.name}.");
            }
            else
            {
                Debug.LogWarning($"{ItemName} does not have a prefab assigned.");
            } 
        }
        
        
   

  
    }
}
