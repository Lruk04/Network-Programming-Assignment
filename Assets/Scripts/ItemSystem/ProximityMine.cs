using System;
using System.Collections;
using System.Collections.Generic;
using ItemSystem;
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
                
            if(IsServer)
            {
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), Owner.GetComponent<Collider>());
            }
        }

        public override void TriggerTrap()
        {
            
            if(IsServer)
            {
                StartCoroutine(FlashColor(5));

                
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == Owner || _triggered) return;
            
            TriggerTrap();
            
            _triggered = true;
            
            Debug.Log($"{TrapName} triggered by {other.name}.");
        }

       
    }
}