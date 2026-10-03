using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class ProjectInstaller : MonoInstaller<ProjectInstaller>
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            
        }
    }
}
