using System;
using System.Collections;
using System.Collections.Generic;
using ItemSystem;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;



namespace ItemSystem
{
    public class ProximityMine : BaseTrapBehaviour
    {
        
        private SpriteRenderer _sprite;

        private float _targetScale = 5;

        private bool _triggered = false;
        
        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();

            _targetScale *= transform.localScale.x;

           
            if (IsServer)
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), Owner.GetComponent<Collider2D>());
                IgnoreCollisionClientRpc(Owner);
            }


            
        }
    
        public override void TriggerTrap()
        {
            if(!IsOwner) return;
            
            if(IsServer)
            {
                StartCoroutine(FlashColor(5));
                TriggerTrapClientRpc();
                
            }
            else
            { 
                TriggerTrapServerRpc();
            }
            
        }

        private IEnumerator ScaleOverTime(Vector3 targetScale, float duration)
        {
            Vector3 initialScale = transform.localScale;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.localScale = targetScale;
        }
       

        private IEnumerator FlashColor(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _sprite.color = Color.red;
                yield return new WaitForSeconds(0.1f);
                _sprite.color = Color.white;
                yield return new WaitForSeconds(0.1f);
            }
            
            _sprite.color = Color.white;
            StartCoroutine(ScaleOverTime(new Vector3(_targetScale, _targetScale, _targetScale), 1f));
        }

        
        [ServerRpc(RequireOwnership = false)]
        private void TriggerTrapServerRpc()
        {
            StartCoroutine(FlashColor(5));
            TriggerTrapClientRpc();
            
        }
        [ClientRpc]
        private void TriggerTrapClientRpc()
        {
            StartCoroutine(FlashColor(5));
        }
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == Owner || _triggered) return;
            
            TriggerTrap();
            
            _triggered = true;
            
            Debug.Log($"{TrapName} triggered by {other.name}.");
        }
        [ClientRpc]
        private void IgnoreCollisionClientRpc(NetworkObjectReference ownerReference)
        {
            if (ownerReference.TryGet(out var owner))
            {
                Collider2D ownerCollider = owner.GetComponent<Collider2D>();
                Collider2D mineCollider = gameObject.GetComponent<Collider2D>();

                if (ownerCollider != null && mineCollider != null)
                {
                    Physics2D.IgnoreCollision(mineCollider, ownerCollider);
                }
            }
        }
       
    }
}