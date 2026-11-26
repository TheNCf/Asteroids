using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Scripts.Tests
{
    public class BonusSpawner : MonoBehaviour
    {
        [SerializeField] private List<BonusInfo> _bonuses;

        private void Awake()
        {
            foreach (var bonusInfo in _bonuses)
            {
                float roll = Random.Range(0f, 100f);

                if (bonusInfo.Chance >= roll)
                {
                    //Instantiate();
                    break;
                }
            }
        }
    }
}