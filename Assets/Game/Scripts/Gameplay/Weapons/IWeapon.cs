using System;
using UniRx;

namespace Game.Scripts.Gameplay.Weapons
{
    public interface IWeapon : IDisposable
    {
        public IReadOnlyReactiveProperty<bool> IsReady { get; }
        public IReadOnlyReactiveProperty<float> CooldownProgress { get; }
        
        void Fire();
    }
}