using Game.Scripts.Core;
using Game.Scripts.Gameplay.Configs;
using Game.Scripts.Gameplay.Weapons.Projectiles.Laser;
using UnityEngine;

namespace Game.Scripts.Gameplay.Spawners
{
    public class LaserSpawner
    {
        private readonly ObjectPool<LaserView> _pool;
        
        private readonly LaserConfig _laserConfig;

        public LaserSpawner(ObjectPool<LaserView> pool, LaserConfig laserConfig)
        {
            _pool = pool;
            _laserConfig = laserConfig;
        }

        public LaserView Spawn(Vector2 position, Vector2 direction)
        {
            LaserView view = _pool.Get();
            view.transform.position = position;
            view.transform.right = direction;
            view.Laser.Animation.PlayStart();
            
            view.Laser.Returner.Activate(_laserConfig.Duration);
            view.Laser.Returner.Expired += Return;
            
            return view;
        }
        private void Return(IPoolableObject poolableObject)
        {
            if (poolableObject is LaserView laser == false)
                return;
            
            laser.Laser.Animation.PlayStop();
            laser.Laser.Animation.AnimationStopFinished += () => _pool.Release(laser);
        }
    }
}