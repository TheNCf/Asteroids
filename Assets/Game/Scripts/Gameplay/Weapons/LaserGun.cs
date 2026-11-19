using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Gameplay.Configs;
using Game.Scripts.Gameplay.Views;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Gameplay.Weapons
{
    public class LaserGun : IWeapon
    {
        private LaserGunConfig _config;
        private PlayerCharacterView _characterView;
        
        private readonly CooldownTimer _cooldownTimer;
        
        private readonly ReactiveProperty<int> _charges = new(0);
        
        public LaserGun(LaserGunConfig config, PlayerCharacterView characterView)
        {
            _config = config;
            _characterView = characterView;
            
            _cooldownTimer = new CooldownTimer(_config.Cooldown);
        }
        
        public IReadOnlyReactiveProperty<bool> IsReady => _cooldownTimer.IsReady;
        public IReadOnlyReactiveProperty<float> CooldownProgress => _cooldownTimer.Progress;
        public IReadOnlyReactiveProperty<int> Charges => _charges;
        
        public void Fire()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}