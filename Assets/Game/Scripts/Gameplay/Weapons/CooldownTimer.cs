using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Gameplay.Weapons
{
    public class CooldownTimer : IDisposable
    {
        private float _duration = 0;
        
        private readonly ReactiveProperty<bool> _isReady = new(true);
        private readonly ReactiveProperty<float> _progress = new(0f);
        
        private CancellationTokenSource _cts;

        public CooldownTimer(float duration)
        {
            _duration = duration;
        }
        
        public IReadOnlyReactiveProperty<bool> IsReady => _isReady;
        public IReadOnlyReactiveProperty<float> Progress => _progress;

        public void Start()
        {
            ResetToken();
            RunAsync(_cts.Token).Forget();
        }

        public void Cancel()
        {
            ResetToken();
            _progress.Value = 1.0f;
            _isReady.Value = true;
        }
        
        public void Dispose()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _isReady.Dispose();
            _progress.Dispose();
        }

        private async UniTaskVoid RunAsync(CancellationToken token)
        {
            _isReady.Value = false;
            _progress.Value = 0;
            
            float startTime = Time.time;

            while (Time.time - startTime < _duration)
            {
                _progress.Value += Mathf.Clamp01((Time.time - startTime) / _duration);
                
                bool isCanceled = await UniTask.Yield(PlayerLoopTiming.Update, token).SuppressCancellationThrow();
                
                if (isCanceled)
                    return;
            }
            
            _progress.Value = 1;
            _isReady.Value = true;
        }

        private void ResetToken()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = new CancellationTokenSource();
        }
    }
}