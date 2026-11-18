using System;
using Game.Scripts.Core;
using UnityEngine;

namespace Game.Scripts.Gameplay.Views
{
    public class LaserView : MonoBehaviour, IPoolableObject
    {
        public event Action<Collider2D> Collided;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Collided?.Invoke(other);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void ResetObject()
        {
            gameObject.SetActive(false);
        }
    }
}