using Game.Scripts.Core;
using Game.Scripts.Gameplay.Movement;
using Game.Scripts.Gameplay.Movement.Objects;
using Game.Scripts.Gameplay.Signals;
using Game.Scripts.Gameplay.Spawners;
using Game.Scripts.Gameplay.Views;
using Game.Scripts.Gameplay.Weapons;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class GameplayInstaller : MonoInstaller<GameplayInstaller>
    {
        [SerializeField] private PlayerCharacterView _playerCharacterViewPrefab;
        
        [SerializeField] private BulletView _bulletPrefab;
        [SerializeField] private int _initialPoolSize;

        public override void InstallBindings()
        {
            DeclareSignals();
            
            BindMovableRegistry();
            BindMovingService();
            
            BindPlayerCharacterView();
            BindPlayerCharacterMovement();
            BindPlayerCharacterMovementInputHandler();
            
            BindBulletPool();
            BindBulletSpawner();
            BindMachineGun();
            Container
                .BindInterfacesAndSelfTo<LaserGun>()
                .AsSingle()
                .NonLazy();
            BindWeaponInputHandler();
        }

        private void BindWeaponInputHandler()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerCharacterWeaponInputHandler>()
                .AsSingle()
                .NonLazy();
        }

        private void BindMachineGun()
        {
            Container
                .BindInterfacesAndSelfTo<MachineGun>()
                .AsSingle()
                .NonLazy();
        }

        private void BindBulletSpawner()
        {
            Container
                .BindInterfacesAndSelfTo<BulletSpawner>()
                .AsSingle()
                .NonLazy();
        }

        private void BindBulletPool()
        {
            Container.Bind<ObjectPool<BulletView>>()
                .FromMethod(ctx => ObjectPoolFactory.CreateMonoPool(
                    Container,
                    _bulletPrefab,
                    _initialPoolSize,
                    bullet => bullet.Activate(),
                    bullet => bullet.ResetObject()
                ))
                .AsSingle();
        }

        private void BindPlayerCharacterMovementInputHandler()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerCharacterMovementInputHandler>()
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayerCharacterMovement()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerCharacterMovement>()
                .AsSingle()
                .NonLazy();
        }

        private IfNotBoundBinder BindPlayerCharacterView()
        {
            return Container
                .Bind<PlayerCharacterView>()
                .FromComponentInNewPrefab(_playerCharacterViewPrefab)
                .AsSingle()
                .NonLazy();
        }

        private void BindMovingService()
        {
            Container
                .BindInterfacesAndSelfTo<MovingService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindMovableRegistry()
        {
            Container
                .BindInterfacesAndSelfTo<MovableRegistry>()
                .AsSingle()
                .NonLazy();
        }

        private void DeclareSignals()
        {
            Container.DeclareSignal<PlayerCharacterHitSignal>();
            Container.DeclareSignal<InvulnerabilityEndedSignal>();
            Container.DeclareSignal<PlayerLoseSignal>();
            Container.DeclareSignal<EnemyDestroySignal>();
        }
    }
}