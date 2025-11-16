using System.Collections;
using Data;
using Enemies.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Enemies.Components
{
    [RequireComponent(typeof(Animator))]
    public class ConstantEventShooter : MonoBehaviour
    {
        [SerializeField] private ShooterData data;
        [SerializeField] private string animationEventName;
        [SerializeField] private UnityEvent shootEvent;

        private Animator _animator;
        private int _shootAnimId;
        private bool _playerAlive;

        private void Awake()
        {
            _playerAlive = true;
            if (animationEventName != null)
            {
                _animator = GetComponent<Animator>();
                _shootAnimId = Animator.StringToHash(animationEventName);
            }
        }

        private void Start()
        {
            PlayerStats.Instance.onDeath.AddListener(StopAttacking);
            StartCoroutine(Attack());
        }

        private IEnumerator Attack()
        {
            while (_playerAlive)
            {
                yield return new WaitForSeconds(data.GetTimeUntilNextShot());
                if (animationEventName != null)
                {
                    _animator.SetBool(_shootAnimId, true);
                }
                yield return new WaitForSeconds(data.ShotDelay);
                shootEvent.Invoke();
                yield return new WaitForSeconds(data.TimeOpen);
                if (animationEventName != null)
                {
                    _animator.SetBool(_shootAnimId, false);
                }
            }
        }

        private void StopAttacking()
        {
            _playerAlive = false;
        }
    }
}