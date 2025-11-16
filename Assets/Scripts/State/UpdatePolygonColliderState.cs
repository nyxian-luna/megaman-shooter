using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class UpdatePolygonColliderState : StateMachineBehaviour
    {
        private List<Vector2> _physicsShapeVertices;
        private bool _needsUpdate;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _needsUpdate = true;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _needsUpdate = false;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!_needsUpdate)
            {
                return;
            }
            
            var collider = animator.GetComponent<PolygonCollider2D>();
            if (collider == null)
            {
                Debug.LogError($"Missing PolygonCollider2D on {animator.gameObject.name}.");
            }
            
            // Get the new list of vertices and set it on the collider.
            _physicsShapeVertices ??= GetPhysicsShapeVertices(animator);
            collider.SetPath(0, _physicsShapeVertices);

            _needsUpdate = false;
        }

        private List<Vector2> GetPhysicsShapeVertices(Animator animator)
        {
            var spriteRenderer = animator.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                Debug.LogError($"Missing SpriteRenderer on {animator.gameObject.name}.");
            }
                
            var sprite = spriteRenderer.sprite;
            if (sprite == null)
            {
                Debug.LogError($"SpriteRenderer on {animator.gameObject.name} has no sprite.");
            }
        
            List<Vector2> physicsShapeVertices = new();
            sprite.GetPhysicsShape(0, physicsShapeVertices);

            return physicsShapeVertices;
        }
    }
}