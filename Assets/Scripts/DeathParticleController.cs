using UnityEngine;

public class DeathParticleController : MonoBehaviour
{
    private Vector2 _direction = new(1, 0);
    private float _speed = 5f;

    public void SetMovement(Vector2 direction, float speed)
    {
        _direction = direction.normalized;
        _speed = speed;
    }

    private void Update()
    {
        var step = _speed * Time.deltaTime;
        var newPosition = (Vector2) transform.position + _direction * step;
        transform.position = newPosition;

        if (newPosition.x < Constants.MinX - 1
            || newPosition.x > Constants.MaxX + 1
            || newPosition.y < Constants.MinY - 1
            || newPosition.y > Constants.MaxY + 1)
        {
            Destroy(gameObject);
        }
    }
}
