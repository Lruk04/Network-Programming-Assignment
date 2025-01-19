// using UnityEngine;
//
// namespace ItemSystem
// {
//     public class ItemFactory : MonoBehaviour
//     {
//         public static Item CreateItem(ItemBehavior behavior, int initialStack = 1)
//         {
//             return new Item(
//                 itemID: behavior.name, // Use ScriptableObject name as ID
//                 itemName: behavior.DisplayName,
//                 icon: behavior.Icon,
//                 description: behavior.Description,
//                 behavior: behavior,
//                 initialStack: initialStack
//             );
//         }
//     }
// }