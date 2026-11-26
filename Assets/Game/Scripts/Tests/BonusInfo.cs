using System;
using UnityEngine;

namespace Game.Scripts.Tests
{
    [Serializable]
    public struct BonusInfo
    {
        [field: SerializeField] public GameObject BonusPrefab { get; private set; }
        [field: SerializeField] public float Chance { get; private set; }
        [field: SerializeField] public float HeightDelta { get; private set; }
    }
}