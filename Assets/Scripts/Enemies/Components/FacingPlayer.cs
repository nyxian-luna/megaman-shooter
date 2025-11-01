using Data;
using UnityEngine;

namespace Enemies.Components
{
    public class FacingPlayer : MonoBehaviour
    {
        private const string PlayerTag = "Player";

        private Transform _player;
        private bool _lookingLeft = true;

        private void Awake()
        {
            var playerObject = GameObject.Find(PlayerTag);
            if (playerObject == null)
            {
                Debug.Log("FacingPlayer: Object with 'Player' tag missing. Disabling.");
                StopFlipping();
            }
            else
            {
                _player = playerObject.transform;
            }
        }

        private void Start()
        {
            PlayerStats.Instance.onDeath.AddListener(StopFlipping);
        }

        private void Update()
        {
            var isLeft = _player.position.x < transform.position.x;
            if (isLeft == _lookingLeft)
            {
                return;
            }
            
            // Direction change. Flip.
            var scale = transform.localScale;
            transform.localScale = new Vector3(scale.x * -1, scale.y, 1);
            _lookingLeft = isLeft;
        }

        private void StopFlipping()
        {
            enabled = false;
        }
    }
}