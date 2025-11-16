using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private Vector2 _direction;

    protected abstract Vector2 GetInitialDirection();

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public float GetDamage()
    {
        return damage;
    }

    private void Awake()
    {
        _direction = GetInitialDirection();
    }

    private void Update()
    {
        var scale = speed * Time.deltaTime;
        transform.position += (Vector3) _direction * scale;
        if (transform.position.y < -1 || transform.position.y > 11 || 
            transform.position.x < -1 || transform.position.x > 19)
        {
            Destroy(gameObject);
        }
    }

    public void FlipDirection()
    {
        _direction.x *= -1;
    }

    public void Ricochet()
    {
        FlipDirection();
        _direction.y = Random.Range(-0.75f, 0.75f);
    }
}