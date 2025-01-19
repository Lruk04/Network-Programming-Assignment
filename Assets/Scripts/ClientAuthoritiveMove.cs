using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;


public class ClientAuthoritativeMovement : NetworkBehaviour
{
 
    
    public float Speed = 5;

    private Vector2 movement;
    void Update()
    {   
       
        
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
