using Game.Scripts.Gameplay.Signals;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class GameplayInstaller : MonoInstaller<GameplayInstaller>
    {
        public override void InstallBindings()
        {
            DeclareSignals();
        }

        private void DeclareSignals()
        {
            Container.DeclareSignal<GameStartSignal>();
            Container.DeclareSignal<GamePausedSignal>();
            Container.DeclareSignal<PlayerCharacterHitSignal>();
            Container.DeclareSignal<InvulnerabilityEndedSignal>();
            Container.DeclareSignal<PlayerLoseSignal>();
            Container.DeclareSignal<EnemyDestroySignal>();
        }

        
    }
}