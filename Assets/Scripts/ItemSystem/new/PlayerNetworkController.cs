using ItemSystem;
using UnityEngine;
using Unity.Netcode;

public class PlayerNetworkController : NetworkBehaviour
{
     [ServerRpc(RequireOwnership = false)]
    public void RequestTrapSpawnServerRpc(Vector3 position, ulong clientId)
    {
        GameObject trap = Instantiate(Resources.Load<GameObject>("ProximityMine"), position, Quaternion.identity);
        
        // trap.GetComponent<BaseTrapBehaviour>().Owner = clientId;


        if(IsOwner) Debug.Log(clientId);
        
        trap.GetComponent<BaseTrapBehaviour>().Owner = NetworkManager.Singleton.ConnectedClients[clientId].PlayerObject.gameObject;
        
        trap.GetComponent<NetworkObject>()?.Spawn();
    }
    
    public void RequestTrapSpawn(Vector3 position, ulong clientId)
    {
       
        RequestTrapSpawnServerRpc(position, clientId);
        
    }
} 
