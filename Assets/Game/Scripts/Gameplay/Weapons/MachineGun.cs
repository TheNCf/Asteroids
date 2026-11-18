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
        private MachineGunConfig _machineGunConfig;
        private BulletSpawner _bulletSpawner;
        private PlayerCharacterView _characterView;
        
        private readonly ReactiveProperty<bool> _isReady = new(true);
        private readonly ReactiveProperty<float> _cooldownProgress = new(0f);
        
        private CancellationTokenSource _cts;

        public MachineGun(BulletSpawner bulletSpawner, MachineGunConfig machineGunConfig, PlayerCharacterView characterView)
        {
            _bulletSpawner = bulletSpawner;
            _machineGunConfig = machineGunConfig;
            _characterView = characterView;
        }
        
        public IReadOnlyReactiveProperty<bool> IsReady => _isReady;
        public IReadOnlyReactiveProperty<float> CooldownProgress => _cooldownProgress;
        
        public void Fire()
        {
            if (_isReady.Value == false)
                return;
            
            _bulletSpawner.Spawn(_characterView.transform.position, _characterView.transform.right);
            
            StartCooldownAsync().Forget();
        }
        
        private async UniTaskVoid StartCooldownAsync()
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
        
            _isReady.Value = false;
            _cooldownProgress.Value = 0f;

            float startTime = Time.time;
        
            try
            {
                while (Time.time - startTime < _machineGunConfig.ReloadTime)
                {
                    float elapsed = Time.time - startTime;
                    _cooldownProgress.Value = Mathf.Clamp01(elapsed / _machineGunConfig.ReloadTime);
                
                    await UniTask.Yield(PlayerLoopTiming.Update, _cts.Token);
                }
            }
            catch (OperationCanceledException)
            {
                return;
            }

            _cooldownProgress.Value = 1f;
            _isReady.Value = true;
        }

        public void Dispose()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _isReady?.Dispose();
            _cooldownProgress?.Dispose();
        }
    }
}