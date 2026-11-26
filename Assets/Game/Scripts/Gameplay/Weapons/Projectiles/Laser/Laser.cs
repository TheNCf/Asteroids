namespace Game.Scripts.Gameplay.Weapons.Projectiles.Laser
{
    public class Laser
    {
        private LaserView _laserView;
        
        public Laser(LaserView laserView)
        {
            _laserView = laserView;
            
            Animation = new LaserAnimation(_laserView);
            Returner = new Returner(_laserView);
        }
        
        public LaserAnimation Animation { get; }
        public Returner Returner { get; }
    }
}