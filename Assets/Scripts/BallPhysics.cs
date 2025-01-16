using System;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;


public class BallPhysics : MonoBehaviour
{
    [SerializeField] private float Speed = 5;
     Rigidbody2D _rb;
    Vector2 _velocity;

    public GameObject _prefab;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocity = new Vector2(Random.Range(-Speed, Speed), Random.Range(-Speed, Speed));
        
    }

    // Update is called once per frame
    void Update()
    {
        _velocity = _rb.linearVelocity;
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject test = Instantiate(_prefab, new Vector3(0, 0, 0), Quaternion.identity);
            
            NetworkObject networkObject = test.GetComponent<NetworkObject>();
            
            
            networkObject.Spawn();
            
           
        }
    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
       var direction = Vector2.Reflect(_velocity.normalized, collision.contacts[0].normal);
       _rb.linearVelocity = direction * Speed;
         
    }
}
