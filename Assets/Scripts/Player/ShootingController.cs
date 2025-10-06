using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class ShootingController : MonoBehaviour
    {
        private readonly int _shootAnimId = Animator.StringToHash("isShooting");
        
        private Animator _animator;
        private PlayerInput _playerInput;
        private InputAction _shootAction;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerInput = GetComponent<PlayerInput>();
            
            _shootAction = _playerInput.actions["Shoot"];
            
            _shootAction.started += Shoot;
            _shootAction.canceled += Shoot;
        }

        private void OnDestroy()
        {
            _shootAction.started -= Shoot;
            _shootAction.canceled -= Shoot;
        }

        private void Shoot(InputAction.CallbackContext context)
        {
            _animator.SetBool(_shootAnimId, _shootAction.inProgress);
        }

        public void Die()
        {
            _playerInput.enabled = false;
        }
    }
}