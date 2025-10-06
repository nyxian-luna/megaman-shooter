using System.Collections;
using UnityEngine;

namespace Utils
{
    public class Flash
    {
        private const float FlashDuration = 0.15f;
        private static readonly Color FlashColor = new(1f, 1f, 1f, 0.2f);
        
        public static IEnumerator SingleFlash(SpriteRenderer spriteRenderer)
        {
            var original = spriteRenderer.color;
            spriteRenderer.color = FlashColor;
            yield return new WaitForSeconds(FlashDuration);
            spriteRenderer.color = original;
        }

        public static IEnumerator DurationFlash(SpriteRenderer spriteRenderer, float duration)
        {
            var original = spriteRenderer.color;
            var startTime = Time.time;
            while (Time.time < startTime + duration)
            {
                yield return new WaitForSeconds(FlashDuration);
                spriteRenderer.color = FlashColor;
                yield return new WaitForSeconds(FlashDuration);
                spriteRenderer.color = original;
            }
        }
    }
}