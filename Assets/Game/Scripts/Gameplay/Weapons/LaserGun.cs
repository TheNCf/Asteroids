using UniRx;

namespace Game.Scripts.Gameplay.Weapons
{
    public class LaserGun : IWeapon
    {
        private readonly ReactiveProperty<bool> _isReady = new(true);
        private readonly ReactiveProperty<float> _cooldownProgress = new(0f);
        
        public IReadOnlyReactiveProperty<bool> IsReady => _isReady;
        public IReadOnlyReactiveProperty<float> CooldownProgress => _cooldownProgress;
        
        public void Fire()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}