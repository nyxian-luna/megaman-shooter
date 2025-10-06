using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private InputAction _moveAction;
        private InputAction _flipDirection;
        private Vector2 _movement;
        
        private void Awake()
        {
            var playerInput = GetComponent<PlayerInput>();
            
            _moveAction = playerInput.actions["Move"];
            _moveAction.started += Move;
            _moveAction.performed += Move;
            _moveAction.canceled += Move;
            
            _flipDirection = playerInput.actions["Direction"];
            _flipDirection.performed += FlipDirection;
        }

        private void Update()
        {
            var scale = moveSpeed * Time.deltaTime;
            var delta = _movement * scale;
            var unclampedPos = (Vector2) transform.position + delta;
            transform.position = new Vector2(
                Mathf.Clamp(unclampedPos.x, Constants.PlayerMinX, Constants.PlayerMaxX),
                Mathf.Clamp(unclampedPos.y, Constants.PlayerMinY, Constants.PlayerMaxY));
        }

        private void OnDestroy()
        {
            _flipDirection.performed -= FlipDirection;
            _moveAction.started -= Move;
            _moveAction.performed -= Move;
            _moveAction.canceled -= Move;
        }

        private void Move(InputAction.CallbackContext context)
        {
            _movement = context.ReadValue<Vector2>();
        }

        private void FlipDirection(InputAction.CallbackContext context)
        {
            var scale = transform.localScale;
            transform.localScale = new Vector3(scale.x * -1, scale.y, 1);
        }
    }
}