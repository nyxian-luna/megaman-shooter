using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
    public class StageSelectBoss : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private Sprite _defaultSprite;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            _defaultSprite = _spriteRenderer.sprite;
        }

        public void Select()
        {
            _animator.enabled = true;
        }

        public void Deselect()
        {
            _animator.enabled = false;
            _spriteRenderer.sprite = _defaultSprite;
        }
    }
}