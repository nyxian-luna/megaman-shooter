using System.Collections;
using UnityEngine;

namespace Enemies.Data
{
    [CreateAssetMenu(fileName = "ShooterData", menuName = "Enemies/Shooter")]
    public class ShooterData : EnemyData
    {
        [Header("Core")]
        [SerializeField] private Projectile projectile;
        [SerializeField] private float fireRateLowerBound = 1f;
        [SerializeField] private float fireRateUpperBound = 3f;

        [Header("Cluster (successive shots)")]
        [Tooltip("Number of successive shots")]
        [SerializeField] private int shotsPerCluster = 1;
        [Tooltip("Time between successive shots (in seconds)")]
        [SerializeField] private float clusterShotSeparation = 0.2f;
        
        [Header("Animation (for shooting)")]
        [Tooltip("Additional delay before shot for animation")]
        [SerializeField] private float shotDelay = 0f;
        [Tooltip("Time the enemy stays open")]
        [SerializeField] private float timeOpen = 0f;
        
        public int GetShotsPerCluster => shotsPerCluster;
        public float GetClusterShotSeparation => clusterShotSeparation;
        public float ShotDelay => shotDelay;
        public float TimeOpen => timeOpen;
         
        public float GetTimeUntilNextShot()
        {
            return Random.Range(fireRateLowerBound, fireRateUpperBound);
        }

        public IEnumerator Shoot(Transform transform, Quaternion rotation = default)
        {
            for (var clusterShot = 1; clusterShot <= shotsPerCluster; clusterShot++)
            {
                if (clusterShot > 1)
                {
                    // Do not wait for the first shot, only on subsequent ones.
                    yield return new WaitForSeconds(clusterShotSeparation);
                }
                Instantiate(projectile, transform.position, rotation);
            }
        }
    }
}