using Game.Scripts.Core.Signals;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class ProjectInstaller : MonoInstaller<ProjectInstaller>
    {
        public override void InstallBindings()
        {
            InstallSignals();
            
            BindGameStateService();
            BindGameStateChanger();
        }

        private void BindGameStateChanger()
        {
            Container
                .BindInterfacesAndSelfTo<GameStateChanger>()
                .AsSingle()
                .NonLazy();
        }

        private void BindGameStateService()
        {
            Container
                .BindInterfacesAndSelfTo<GameStateService>()
                .AsSingle()
                .NonLazy();
        }

        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<GameStateChangedSignal>();
        }
    }
}
