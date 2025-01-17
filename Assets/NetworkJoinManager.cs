using Unity.Netcode;
using UnityEngine;

public class NetworkJoinManager : NetworkBehaviour
{
    public void HostGame()
    {
        NetworkManager.Singleton.StartHost();
    }
    public void JoinGame()
    {
        NetworkManager.Singleton.StartClient();
    }
}
