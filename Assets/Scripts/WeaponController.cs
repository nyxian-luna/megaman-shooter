using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public Projectile weapon;
    public float autoShootInterval = 0.2f;
    
    private PlayerInput _playerInput;
    private InputAction _shootAction;
    private InputAction _flipDirection;
    private bool _isReverseDirection;
    private Coroutine _autoShootRoutine;

    private void Awake()
    {
        _playerInput = transform.GetComponent<PlayerInput>();
        
        _shootAction = _playerInput.actions["Shoot"];
        _flipDirection = _playerInput.actions["Direction"];

        _shootAction.started += ShootStart;
        _shootAction.performed += Shoot;
        _shootAction.canceled += ShootStop;
        _flipDirection.performed += FlipDirection;
    }

    private void OnDestroy()
    {
        _shootAction.started -= ShootStart;
        _shootAction.performed -= Shoot;
        _shootAction.canceled -= ShootStop;
        _flipDirection.performed -= FlipDirection;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        CreateBullet();
    }

    private void ShootStart(InputAction.CallbackContext context)
    {
        _autoShootRoutine = StartCoroutine(AutoShoot());
    }

    private void ShootStop(InputAction.CallbackContext context)
    {
        
        StopCoroutine(_autoShootRoutine);
    }

    private void FlipDirection(InputAction.CallbackContext context)
    {
        _isReverseDirection = !_isReverseDirection;
    }

    private IEnumerator AutoShoot()
    {
        while (_shootAction.inProgress)
        {
            yield return new WaitForSeconds(autoShootInterval);
            if (_shootAction.inProgress)
            {
                CreateBullet();
            }
        }
    }

    private void CreateBullet()
    {
        var bullet = Instantiate(weapon, transform.position, Quaternion.identity);
        if (_isReverseDirection)
        {
            bullet.FlipDirection();
        }
    }

    public void Disable()
    {
        _playerInput.enabled = false;
    }
}
