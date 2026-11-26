using Game.Scripts.Gameplay.Configs;
using Game.Scripts.Gameplay.Player;
using Game.Scripts.Gameplay.Spawners;
using UniRx;

namespace Game.Scripts.Gameplay.Weapons
{
    public class LaserGun : IWeapon
    {
        private readonly LaserGunConfig _config;
        private readonly PlayerCharacterView _characterView;
        private readonly LaserSpawner _spawner;
        
        private readonly CooldownTimer _fireCooldown;
        private readonly CooldownTimer _rechargeTimer;
        
        private readonly ReactiveProperty<int> _charges = new(0);
        
        private CompositeDisposable _disposables = new CompositeDisposable();
        
        public LaserGun(LaserGunConfig config, PlayerCharacterView characterView, LaserSpawner spawner)
        {
            _config = config;
            _characterView = characterView;
            _spawner = spawner;

            _fireCooldown = new CooldownTimer(_config.Cooldown);
            _rechargeTimer = new CooldownTimer(_config.ReloadTime);
            _charges.Value = _config.MaxAmount;
            
            InitializeRechargeLogic();
        }
        
        public IReadOnlyReactiveProperty<bool> IsReady => _fireCooldown.IsReady;
        public IReadOnlyReactiveProperty<float> CooldownProgress => _fireCooldown.Progress;
        public IReadOnlyReactiveProperty<float> RechargeProgress => _rechargeTimer.Progress;
        public IReadOnlyReactiveProperty<int> Charges => _charges;
        
        public void Fire()
        {
            if (IsReady.Value == false || _charges.Value < 1)
                return;

            _charges.Value--;
            _spawner.Spawn(_characterView.transform.position, _characterView.transform.right);
            
            _fireCooldown.Start();
        }

        public void Dispose()
        {
            _disposables.Dispose();
            _fireCooldown.Dispose();
            _rechargeTimer.Dispose();
            _charges.Dispose();
        }

        private void InitializeRechargeLogic()
        {
            _rechargeTimer.IsReady
                .Where(isReady => isReady && _charges.Value < _config.MaxAmount)
                .Subscribe(_ => _charges.Value++)
                .AddTo(_disposables);
            
            _charges.
                Where(count => count < _config.MaxAmount && _rechargeTimer.IsReady.Value).
                Subscribe(count => _rechargeTimer.Start())
                .AddTo(_disposables);
        }
    }
}