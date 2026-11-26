using System;
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
            Returner = new Returner(_view);
        }
        
        public Returner Returner { get; }
        public BulletMover Mover { get; }
    }
}