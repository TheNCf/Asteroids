namespace Game.Scripts.Gameplay.Configs
{
    public class PlayerCharacterConfig
    {
        public PlayerCharacterConfig(int startHealth, float rotationSpeed, float maxSpeed, float thrustForce, float invulnerabilitySeconds)
        {
            StartHealth = startHealth;
            RotationSpeed = rotationSpeed;
            MaxSpeed = maxSpeed;
            ThrustForce = thrustForce;
            InvulnerabilitySeconds = invulnerabilitySeconds;
        }

        public int StartHealth { get; private set; }
        public float RotationSpeed { get; private set; }
        public float MaxSpeed { get; private set; }
        public float ThrustForce { get; private set; }
        public float InvulnerabilitySeconds { get; private set; }
    }
}