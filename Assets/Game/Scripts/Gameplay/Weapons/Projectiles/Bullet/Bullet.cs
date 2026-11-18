using System;
using Game.Scripts.Gameplay.Movement.Objects;
using Game.Scripts.Gameplay.Views;
using Zenject;

namespace Game.Scripts.Gameplay.Weapons.Projectiles.Bullet
{
    public class Bullet
    {
        private readonly BulletView _view;
        
        public Bullet(BulletView view)
        {
            _view = view;
            
            Mover = new BulletMover(_view);
            Returner = new BulletReturner(_view);
        }
        
        public BulletReturner Returner { get; }
        public BulletMover Mover { get; }
    }
}