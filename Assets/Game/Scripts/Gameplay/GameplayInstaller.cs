using Game.Scripts.Gameplay.Movement;
using Game.Scripts.Gameplay.Signals;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class GameplayInstaller : MonoInstaller<GameplayInstaller>
    {
        public override void InstallBindings()
        {
            DeclareSignals();
            
            BindMovableRegistry();
            BindMovingService();
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