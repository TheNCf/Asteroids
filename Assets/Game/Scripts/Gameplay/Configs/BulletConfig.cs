namespace Game.Scripts.Gameplay.Configs
{
    public class BulletConfig
    {
        public BulletConfig(float speed)
        {
            Speed = speed;
        }

        public float Speed { get; private set; }
    }
}