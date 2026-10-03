namespace Game.Scripts.Gameplay.Configs
{
    public class LaserConfig
    {
        public LaserConfig(float duration)
        {
            Duration = duration;
        }
        
        public float Duration { get; private set; }
    }
}