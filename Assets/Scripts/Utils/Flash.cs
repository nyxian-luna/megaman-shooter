using System.Collections;
using UnityEngine;

namespace Utils
{
    public class Flash
    {
        private const float FlashDuration = 0.15f;
        private static readonly Color FlashColor = new(1f, 1f, 1f, 0.2f);
        
        public static IEnumerator SingleFlash(SpriteRenderer spriteRenderer, float flashSpeed = FlashDuration)
        {
            var original = spriteRenderer.color;
            spriteRenderer.color = FlashColor;
            yield return new WaitForSeconds(flashSpeed);
            spriteRenderer.color = original;
        }

        public static IEnumerator DurationFlash(
            SpriteRenderer spriteRenderer, float duration, float flashSpeed = FlashDuration)
        {
            var original = spriteRenderer.color;
            var startTime = Time.time;
            while (Time.time < startTime + duration)
            {
                yield return new WaitForSeconds(flashSpeed);
                spriteRenderer.color = FlashColor;
                yield return new WaitForSeconds(flashSpeed);
                spriteRenderer.color = original;
            }
        }
    }
}