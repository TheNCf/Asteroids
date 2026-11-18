using System;
using Game.Scripts.Gameplay.Configs;
using Game.Scripts.Gameplay.Views;
using UnityEngine;

namespace Game.Scripts.Gameplay.Movement.Objects
{
    public class PlayerCharacterMovement : IMovable, IDisposable
    {
        private readonly MovableRegistry _registry;
        private readonly PlayerCharacterConfig _config;
        private readonly PlayerCharacterView _playerCharacterView;

        private Vector2 _position;

        public PlayerCharacterMovement(MovableRegistry registry, PlayerCharacterConfig config, PlayerCharacterView playerCharacterView)
        {
            _registry = registry;
            _config = config;
            _playerCharacterView = playerCharacterView;

            _registry.Register(this);
        }

        public Vector2 Position
        {
            get => _position;
            private set
            {
                _position = value;
                _playerCharacterView.transform.position = _position;
            }
        }
        public Vector2 Velocity { get; private set; }
        
        public void Move(Vector2 delta)
        {
            Position += delta;
        }

        public void Move(float deltaX = 0, float deltaY = 0)
        {
            Vector2 delta = new Vector2(deltaX, deltaY);
            Move(delta);
        }

        public void ChangeVelocity(Vector2 newVelocity)
        {
            if (Mathf.Pow(_config.MaxSpeed, 2) < newVelocity.sqrMagnitude)
                newVelocity = newVelocity.normalized * _config.MaxSpeed;
            
            Velocity = newVelocity;
        }

        public void Rotate(float deltaAngle)
        {
            _playerCharacterView.transform.Rotate(0, 0, deltaAngle);
        }

        public void Dispose()
        {
            _registry.Unregister(this);
        }
    }
}