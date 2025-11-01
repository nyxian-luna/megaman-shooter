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
        
        public int GetShotsPerCluster => shotsPerCluster;
        public float GetClusterShotSeparation => clusterShotSeparation;
         
        public float GetTimeUntilNextShot()
        {
            return Random.Range(fireRateLowerBound, fireRateUpperBound);
        }

        public Projectile CreateProjectile(Transform transform, Quaternion rotation = default)
        {
            return Instantiate(projectile, transform.position, rotation);
        }
    }
}