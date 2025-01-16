using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;


public class ClientAuthoritativeMovement : NetworkBehaviour
{
    /// <summary>
    /// Movement Speed
    /// </summary>
    public float Speed = 5;

    private Vector2 movement;
    void Update()
    {
 
        // if (!IsOwner || !IsSpawned) return;
        //
        // var multiplier = Speed * Time.deltaTime;
        //
        // if (Keyboard.current.aKey.isPressed)
        // {
        //     transform.position += new Vector3(-multiplier, 0, 0);
        // }
        // else if (Keyboard.current.dKey.isPressed)
        // {
        //     transform.position += new Vector3(multiplier, 0, 0);
        // }
        // else if (Keyboard.current.wKey.isPressed)
        // {
        //     transform.position += new Vector3(0, -multiplier, 0);
        // }
        // else if (Keyboard.current.sKey.isPressed)
        // {
        //     transform.position += new Vector3(0, -multiplier, 0);
        // }
        
        if (!IsOwner || !IsSpawned) return;

        if(PlayerStateHandling.Instance.MovementPaused)
            return;
        
        var multiplier = Speed * Time.deltaTime;
        
        
        transform.position += new Vector3(movement.x * multiplier, movement.y * multiplier, 0);
    }
    private void OnMove(InputValue value)
    {
       
        
        movement = value.Get<Vector2>();
        
    }
    
}
