using System.Collections;
using UnityEngine;

namespace Enemies
{
    public class ChopperBlue : Chopper
    {
        protected override IEnumerator Attack()
        {
            while (true)
            {
                yield return new WaitForSeconds(
                    Mathf.Clamp(
                        Random.Range(averageFireRate - 1f, averageFireRate + 1f), 1f, 3f));
                Instantiate(bullet, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
                Instantiate(bullet, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
        }
    }
}