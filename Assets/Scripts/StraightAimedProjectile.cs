using UnityEngine;

public class StraightAimedProjectile : Projectile
{
    protected override Vector2 GetInitialDirection()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var direction = player.transform.position - transform.position;
        direction.Normalize();
        return direction;
    }
}