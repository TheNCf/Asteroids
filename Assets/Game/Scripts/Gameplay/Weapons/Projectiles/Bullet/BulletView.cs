using System;
using Game.Scripts.Core;
using UnityEngine;

namespace Game.Scripts.Gameplay.Weapons.Projectiles.Bullet
{
    public class BulletView : MonoBehaviour, IPoolableObject
    {
        public event Action<Collider2D> Collided;

        public Bullet Bullet { get; private set; }

        private void Awake()
        {
            Bullet = new Bullet(this);
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