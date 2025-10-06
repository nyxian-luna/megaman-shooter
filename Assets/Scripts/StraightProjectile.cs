using UnityEngine;

public class StraightProjectile : Projectile
{
    protected override Vector2 GetInitialDirection()
    {
        return new Vector2(1, 0);
    }
}
