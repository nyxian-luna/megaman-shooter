using Enemies.Components;
using UnityEngine;

namespace State
{
    public class VulnerableState : StateMachineBehaviour
    {
        private EnemyHealthController _healthController;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _healthController ??= animator.GetComponent<EnemyHealthController>();
            if (_healthController == null)
            {
                Debug.LogError(
                    $"VulnerableState: EnemyHealthController component missing from {animator.gameObject.name}.");
            }
            
            _healthController.MakeVulnerable();
        }
    }
}