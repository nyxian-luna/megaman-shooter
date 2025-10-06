using System.Collections;
using UnityEngine;

namespace Enemies
{
    public class ChopperGreen : Chopper
    {
        protected override IEnumerator Attack()
        {
            while (true)
            {
                yield return new WaitForSeconds(
                    Mathf.Clamp(
                        Random.Range(averageFireRate - 1f, averageFireRate + 1f), 1f, 3f));
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
        }
    }
}
