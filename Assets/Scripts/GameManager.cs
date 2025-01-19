// using Unity.Netcode;
//
// public class GameManager : NetworkBehaviour
// {
//     private PlayerManager playerManager;
//
//     
//     
//     private void Awake()
//     {
//         playerManager = FindObjectOfType<PlayerManager>();
//     }
//
//     public override void OnNetworkSpawn()
//     {
//         base.OnNetworkSpawn();
//
//         if (IsServer)
//         {
//             // Register the player when they join
//             playerManager.RegisterPlayer(NetworkManager.Singleton.LocalClientId, gameObject);
//         }
//     }
//
//     public override void OnNetworkDespawn()
//     {
//         base.OnNetworkDespawn();
//
//         if (IsServer)
//         {
//             // Unregister the player when they leave
//             playerManager.UnregisterPlayer(NetworkManager.Singleton.LocalClientId);
//         }
//     }
// }
