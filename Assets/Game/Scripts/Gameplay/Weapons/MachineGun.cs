using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Gameplay.Configs;
using Game.Scripts.Gameplay.Spawners;
using Game.Scripts.Gameplay.Views;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Gameplay.Weapons
{
    public class MachineGun : IWeapon
    {
        private MachineGunConfig _config;
        private BulletSpawner _bulletSpawner;
        private PlayerCharacterView _characterView;

        private CooldownTimer _cooldownTimer;
        
        public MachineGun(BulletSpawner bulletSpawner, MachineGunConfig config, PlayerCharacterView characterView)
        {
            _bulletSpawner = bulletSpawner;
            _config = config;
            _characterView = characterView;

            _cooldownTimer = new CooldownTimer(_config.ReloadTime);
        }
        
        public IReadOnlyReactiveProperty<bool> IsReady => _cooldownTimer.IsReady;
        public IReadOnlyReactiveProperty<float> CooldownProgress => _cooldownTimer.Progress;
        
        public void Fire()
        {
            if (IsReady.Value == false)
                return;
            
            _bulletSpawner.Spawn(_characterView.transform.position, _characterView.transform.right);
            
            _cooldownTimer.Start();
        }

        public void Dispose()
        {
            
        }
    }
}