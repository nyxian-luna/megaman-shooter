using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Stages.CutMan
{
    public class CutManStage : MonoBehaviour
    {
        [SerializeField] private int encounterCount;

        private EnemySpawner _spawner;
        private readonly List<IEncounter> _encounters = new()
        {
            new EncounterNineRight(),
            new EncounterFourEachSide(),
            new EncounterWigglers(),
            new EncounterTwoCircles()
        };

        private void Awake()
        {
            _spawner = GetComponent<EnemySpawner>();
        }

        private void Start()
        {
            StartCoroutine(RunStage());
        }

        private IEnumerator RunStage()
        {
            var random = new System.Random();
            
            var encounters = 0;
            while (encounters < encounterCount)
            {
                var encounterIndex = random.Next(0, _encounters.Count);
                yield return StartCoroutine(RunEncounter(encounterIndex));
                encounters++;
            
                // Wait 5 seconds before the next encounter.
                yield return new WaitForSeconds(5);
            }
        }

        private IEnumerator RunEncounter(int encounterIndex)
        {
            var encounter = _encounters[encounterIndex];
            var aliveEnemies = encounter.Spawn(_spawner);

            while (aliveEnemies.Count > 0)
            {
                yield return new WaitForSeconds(1);
                aliveEnemies.RemoveAll(enemy => enemy.IsDestroyed());
            }
        }
    }
}
