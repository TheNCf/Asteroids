using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Core;
using Game.Scripts.Gameplay.Weapons.Projectiles.Laser;

namespace Game.Scripts.Gameplay.Weapons.Projectiles
{
    public class Returner
    {
        private readonly IPoolableObject _poolableObject;
        private readonly CancellationTokenSource _cts = new();

        private float _lifeTime;
        
        private bool _isExpired = false;

        public event Action<IPoolableObject> Expired;

        public Returner(IPoolableObject poolableObject)
        {
            _poolableObject = poolableObject;
        }

        public void Activate(float lifeTime)
        {
            _lifeTime = lifeTime;
            _isExpired = false;
            StartLifeTimerAsync(_cts.Token).Forget();
        }

        private async UniTaskVoid StartLifeTimerAsync(CancellationToken token)
        {
            bool isCanceled = await UniTask.Delay(
                    TimeSpan.FromSeconds(_lifeTime),
                    cancellationToken: token)
                .SuppressCancellationThrow();

            if (!isCanceled)
                Expire();
        }

        private void Expire()
        {
            if (_isExpired)
                return;
            
            _isExpired = true;
            Expired?.Invoke(_poolableObject);
        }
        
        public void Dispose()
        {
            if (!_cts.IsCancellationRequested)
                _cts.Cancel();
                
            _cts.Dispose();
        }
    }
}