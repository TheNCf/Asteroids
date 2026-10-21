using Game.Scripts.Gameplay.Configs;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.Movement
{
    public class MovingService : ITickable
    {
        private readonly MovableRegistry _registry;
        
        private WorldConfig _worldConfig;

        private readonly Vector2 _worldExtents;

        public MovingService(MovableRegistry registry, WorldConfig worldConfig)
        {
            _registry = registry;
            _worldConfig = worldConfig;
            
            _worldExtents = new Vector2(_worldConfig.Width, _worldConfig.Height) / 2;
        }

        public void Tick()
        {
            CalculatePositions();
        }

        private void CalculatePositions()
        {
            foreach (var movable in _registry.Movables)
            {
                movable.Move(movable.Velocity * Time.deltaTime);
                
                if (movable.Position.x > _worldExtents.x)
                    movable.Move(-_worldConfig.Width, 0);
                
                if (movable.Position.x < _worldExtents.x)
                    movable.Move(_worldConfig.Width, 0);
                
                if (movable.Position.y > _worldExtents.y)
                    movable.Move(0, -_worldConfig.Height);
                
                if (movable.Position.y < _worldExtents.y)
                    movable.Move(0, _worldConfig.Height);
            }
        }
    }
}