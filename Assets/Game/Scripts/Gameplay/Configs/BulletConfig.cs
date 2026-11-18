namespace Game.Scripts.Gameplay.Configs
{
    public class BulletConfig
    {
        public BulletConfig(float speed, float timeToLive)
        {
            Speed = speed;
            TimeToLive = timeToLive;
        }

        public float Speed { get; private set; }
        public float TimeToLive { get; private set; }
    }
}