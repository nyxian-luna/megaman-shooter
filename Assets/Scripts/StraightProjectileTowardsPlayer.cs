using UnityEngine;

public class StraightProjectileTowardsPlayer : Projectile
{
    protected override Vector2 GetInitialDirection()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var x = player.transform.position.x < transform.position.x ? -1 : 1;
        return new Vector2(x, 0);
    }
}