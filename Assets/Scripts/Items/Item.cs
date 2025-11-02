using System.Collections;
using UnityEngine;
using Utils;

namespace Items
{
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class Item : MonoBehaviour
    {
        private const float WarningRatio = 0.7f;
        
        private SpriteRenderer _spriteRenderer;
        
        protected abstract float GetExpirationTime();

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            StartCoroutine(Expire());
        }

        private IEnumerator Expire()
        {
            var expireTime = GetExpirationTime();
            var warningStartTime = expireTime * WarningRatio;
            yield return new WaitForSeconds(warningStartTime);
            yield return Flash.DurationFlash(_spriteRenderer, expireTime - warningStartTime, 0.05f);
            Destroy(gameObject);
        }
    }
}