using System;
using Game.Scripts.Core;
using UnityEngine;

namespace Game.Scripts.Gameplay.Weapons.Projectiles.Laser
{
    public class LaserView : MonoBehaviour, IPoolableObject
    {
        public event Action<Collider2D> Collided;
        
        public Laser Laser { get; private set; }
        
        public void Awake()
        {
            Laser = new Laser(this);
        }

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