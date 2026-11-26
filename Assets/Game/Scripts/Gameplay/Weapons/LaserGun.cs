using Game.Scripts.Gameplay.Configs;
using Game.Scripts.Gameplay.Player;
using Game.Scripts.Gameplay.Spawners;
using UniRx;

namespace Game.Scripts.Gameplay.Weapons
{
    public class LaserGun : IWeapon
    {
        private LaserGunConfig _config;
        private PlayerCharacterView _characterView;
        private LaserSpawner _spawner;
        
        private readonly CooldownTimer _cooldownTimer;
        
        private readonly ReactiveProperty<int> _charges = new(0);
        
        public LaserGun(LaserGunConfig config, PlayerCharacterView characterView, LaserSpawner spawner)
        {
            _config = config;
            _characterView = characterView;
            _spawner = spawner;

            _cooldownTimer = new CooldownTimer(_config.Cooldown);
            _charges.Value = _config.MaxAmount;
        }
        
        public IReadOnlyReactiveProperty<bool> IsReady => _cooldownTimer.IsReady;
        public IReadOnlyReactiveProperty<float> CooldownProgress => _cooldownTimer.Progress;
        public IReadOnlyReactiveProperty<int> Charges => _charges;
        
        public void Fire()
        {
            if (IsReady.Value == false)
                return;
            
            _spawner.Spawn(_characterView.transform.position, _characterView.transform.right);
            
            _cooldownTimer.Start();
        }

        public void Dispose()
        {
            
        }
    }
}