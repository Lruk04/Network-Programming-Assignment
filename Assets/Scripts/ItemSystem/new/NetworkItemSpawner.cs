// using Unity.Netcode;
// using UnityEngine;
//
// namespace ItemSystem
// {
//     public class NetworkItemSpawner : NetworkBehaviour
//     {
//         private static NetworkItemSpawner _instance;
//
//
//         public static NetworkItemSpawner Instance
//         {
//             get
//             {
//                 if (_instance == null)
//                 {
//                     _instance = FindFirstObjectByType<NetworkItemSpawner>();
//                     if (_instance == null)
//                     {
//                         GameObject go = new GameObject();
//                         go.name = nameof(NetworkItemSpawner);
//                         _instance = go.AddComponent<NetworkItemSpawner>();
//                         DontDestroyOnLoad(go);
//                     }
//                 }
//
//                 return _instance;
//             }
//         }
//         
//         
//         public void SpawnItem(GameObject objectSpawn, Vector3 position, Quaternion rotation, GameObject player)
//         {
//             GameObject item = Instantiate(objectSpawn, position, Quaternion.identity);
//             NetworkObject networkObject = item.GetComponent<NetworkObject>();
//             networkObject.Spawn();
//             AssignItemOwnerServerRpc(item.GetComponent<NetworkObject>(), player.GetComponent<NetworkObject>());
//         }
//         
//         [ServerRpc]
//         private void AssignItemOwnerServerRpc(NetworkObjectReference trapReference,
//             NetworkObjectReference playerReference)
//         {
//             if (trapReference.TryGet(out NetworkObject trapObject) &&
//                 playerReference.TryGet(out NetworkObject playerObject))
//             {
//                 var trapBehaviour = trapObject.GetComponent<BaseTrapBehaviour>();
//                 if (trapBehaviour != null)
//                 {
//                     trapBehaviour.Owner = playerObject.gameObject;
//                 }
//             }
//         }
//     }
// }