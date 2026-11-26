using System;
using UnityEngine;

namespace Game.Scripts.Gameplay.Player
{
    public class PlayerCharacterView : MonoBehaviour
    {
        public event Action<Collider2D> EnteredTrigger;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            EnteredTrigger?.Invoke(other);
        }
    }
}