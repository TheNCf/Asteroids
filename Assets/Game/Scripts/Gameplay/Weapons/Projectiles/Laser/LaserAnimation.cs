using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.Gameplay.Weapons.Projectiles.Laser
{
    public class LaserAnimation
    {
        private readonly LaserView _laserView;

        private readonly Vector3 _startSize;
        
        public event Action AnimationStopFinished; 

        public LaserAnimation(LaserView laserView)
        {
            _laserView = laserView;
            
            _startSize = laserView.transform.localScale;
        }

        public void PlayStart()
        {
            _laserView.transform.localScale = new Vector3(0, 0, 1);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(_laserView.transform.DOScaleY(_startSize.y, 0.5f).SetEase(Ease.InQuint));
            sequence.Join(_laserView.transform.DOScaleX(_startSize.x, 3.0f).SetEase(Ease.InQuad));
        }

        public void PlayStop()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(_laserView.transform.DOScaleY(0, 0.5f).SetEase(Ease.InQuint));
            sequence.Join(_laserView.transform.DOScaleX(0, 0.5f).SetEase(Ease.InQuad));
            sequence.OnComplete(() => AnimationStopFinished?.Invoke());
        }
    }
}