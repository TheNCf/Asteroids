using Game.Scripts.Gameplay.Movement;
using UnityEngine;

namespace Game.Scripts.Gameplay.Weapons.Projectiles.Bullet
{
    public class BulletMover : IMovable
    {
        private readonly BulletView _bullet;
        private Vector2 _position;

        public Vector2 Position
        {
            get => _position;
            private set
            {
                _position = value;
                _bullet.transform.position = _position;
            }
        }
        
        public Vector2 Velocity { get; private set; }

        public BulletMover(BulletView bulletView)
        {
            _bullet = bulletView;
        }
        
        public void Move(Vector2 delta)
        {
            Position += delta;
        }

        public void Move(float deltaX = 0, float deltaY = 0)
        {
            Vector2 delta = new Vector2(deltaX, deltaY);
            Move(delta);
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        public void ChangeVelocity(Vector2 newVelocity)
        {
            Velocity = newVelocity;
        }
    }
}