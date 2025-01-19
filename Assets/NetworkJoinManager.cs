using System.Collections.Generic;
using ItemSystem;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;

public class NetworkJoinManager : NetworkBehaviour
{
    [FormerlySerializedAs("_items")] public List<GameObject> _buttons = new List<GameObject>();
    
    
    public void HostGame()
    {
        NetworkManager.Singleton.StartHost();
        DestroyObjects();
    }
    public void JoinGame()
    {
        NetworkManager.Singleton.StartClient();
        DestroyObjects();

    }
    
    private void DestroyObjects()
    {
        foreach (var item in _buttons)
        {
            Destroy(item);
        }
    }
}
