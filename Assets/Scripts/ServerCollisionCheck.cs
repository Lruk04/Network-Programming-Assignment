using Unity.Netcode;
using UnityEngine;

public class ServerCollisionCheck : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        
        if(!IsServer)
        {
            enabled = false;
            
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
