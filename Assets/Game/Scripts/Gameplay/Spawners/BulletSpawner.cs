using Game.Scripts.Core;
using Game.Scripts.Gameplay.Configs;
using Game.Scripts.Gameplay.Movement;
using Game.Scripts.Gameplay.Views;
using UnityEngine;

namespace Game.Scripts.Gameplay.Spawners
{
    public class BulletSpawner
    {
        private readonly ObjectPool<BulletView> _bulletPool;
        
        private readonly BulletConfig _bulletConfig;
        private readonly MovableRegistry _movableRegistry;

        public BulletSpawner(ObjectPool<BulletView> bulletPool, BulletConfig bulletConfig, MovableRegistry movableRegistry)
        {
            _bulletPool = bulletPool;
            _bulletConfig = bulletConfig;
            _movableRegistry = movableRegistry;
        }
        
        public BulletView Spawn(Vector2 position, Vector2 direction)
        {
            BulletView view = _bulletPool.Get();
            
            view.transform.right = direction;
            view.Bullet.Mover.SetPosition(position);
            view.Bullet.Mover.ChangeVelocity(direction.normalized * _bulletConfig.Speed);
            _movableRegistry.Register(view.Bullet.Mover);
            
            view.Bullet.Returner.Activate(_bulletConfig.TimeToLive);

            view.Bullet.Returner.Expired += Return;
            
            return view;
        }

        private void Return(BulletView bullet)
        {
            _movableRegistry.Unregister(bullet.Bullet.Mover);
            _bulletPool.Release(bullet);
        }
    }
}