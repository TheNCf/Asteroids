using Game.Scripts.Gameplay.Movement;
using Game.Scripts.Gameplay.Movement.Objects;
using Game.Scripts.Gameplay.Signals;
using Game.Scripts.Gameplay.Views;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class GameplayInstaller : MonoInstaller<GameplayInstaller>
    {
        [SerializeField] private PlayerCharacterView _playerCharacterViewPrefab;
        
        public override void InstallBindings()
        {
            DeclareSignals();
            
            BindMovableRegistry();
            BindMovingService();
            
            BindPlayerCharacterView();
            BindPlayerCharacterMovement();
            BindPlayerCharacterMovementInputHandler();
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