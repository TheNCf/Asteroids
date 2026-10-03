namespace Game.Scripts.Gameplay.Configs
{
    public class AsteroidConfig
    {
        public AsteroidConfig(float childSizeFactor, int childCount, int divisionsCount, float speed, float childSpeedFactor)
        {
            ChildSizeFactor = childSizeFactor;
            ChildCount = childCount;
            DivisionsCount = divisionsCount;
            Speed = speed;
            ChildSpeedFactor = childSpeedFactor;
        }

        public float ChildSizeFactor { get; private set; }
        public int ChildCount { get; private set; }
        public int DivisionsCount { get; private set; }
        public float Speed { get; private set; }
        public float ChildSpeedFactor { get; private set; }
    }
}