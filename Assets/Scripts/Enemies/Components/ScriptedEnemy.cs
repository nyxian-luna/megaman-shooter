using System;
using System.Collections;
using EnemyScript;
using UnityEngine;

namespace Enemies.Components
{
    public class ScriptedEnemy : MonoBehaviour
    {
        private IEnemyAction[] _actions = Array.Empty<IEnemyAction>();

        private IEnumerator Start()
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
}