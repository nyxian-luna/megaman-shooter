using System.Collections;
using Data;
using EnemyScript;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private readonly int _isDeadAnimId = Animator.StringToHash("isDead");
    
    [SerializeField] protected float health = 10;
    [SerializeField] protected float moveSpeed = 4;
    
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private IEnemyAction[] _actions;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        PlayerStats.Instance.onDeath.AddListener(OnPlayerDeath);
        
        OnStart();
        if (_actions != null)
        {
            StartCoroutine(ExecuteActions());
        }
    }

    protected virtual void OnStart()
    {
        // Does nothing by default.
    }

    protected virtual void OnPlayerDeath()
    {
        // Does nothing by default.
    }

    protected void Hit()
    {
        StartCoroutine(Utils.Flash.SingleFlash(_spriteRenderer));
    }
    
    protected void Die()
    {
        _animator.SetBool(_isDeadAnimId, true);
        GetComponent<Collider2D>().enabled = false;
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    private IEnumerator ExecuteActions()
    {
        foreach (var action in _actions)
        {
            yield return StartCoroutine(action.Action(gameObject));
        }
    }

    public void SetActions(params IEnemyAction[] actions)
    {
        _actions = actions;
    }
}