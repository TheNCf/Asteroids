namespace Game.Scripts.Gameplay.Configs
{
    public class UfoConfig
    {
        public UfoConfig(float maxSpeed)
        {
            MaxSpeed = maxSpeed;
        }

        public float MaxSpeed { get; private set; }
    }
}