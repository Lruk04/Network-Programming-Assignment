using UnityEngine;

namespace ItemSystem
{
    public class TrapData : ItemData
    {
        public GameObject TrapPrefab;

      
       
    
        public override void Use(GameObject player)
        {
            base.Use(player);
        
            PlaceTrap(player);
        }
    
    
        public void PlaceTrap(GameObject player)
        {
            if(TrapPrefab != null)
            {
                Vector3 spawnPosition = player.transform.position + player.transform.up * 2;

                GameObject trapInstance = Object.Instantiate(TrapPrefab, spawnPosition, Quaternion.identity);

                var trapBehaviour = trapInstance.GetComponent<BaseTrapBehaviour>();
                if (trapBehaviour != null)
                {
                    trapBehaviour.Owner = player;
                
                }

                Debug.Log($"{ItemName} placed at {spawnPosition} by {player.name}.");
            }
            else
            {
                Debug.LogWarning($"{ItemName} does not have a prefab assigned.");
            }
        }
    
    

  
    }
}
