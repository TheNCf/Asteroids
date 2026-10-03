namespace Game.Scripts.Gameplay.Configs
{
    public class PlayerCharacterConfig
    {
        public PlayerCharacterConfig(int startHealth, float angularSpeed, float maxSpeed, float thrustForce, float invulnerabilitySeconds)
        {
            StartHealth = startHealth;
            AngularSpeed = angularSpeed;
            MaxSpeed = maxSpeed;
            ThrustForce = thrustForce;
            InvulnerabilitySeconds = invulnerabilitySeconds;
        }

        public int StartHealth { get; private set; }
        public float AngularSpeed { get; private set; }
        public float MaxSpeed { get; private set; }
        public float ThrustForce { get; private set; }
        public float InvulnerabilitySeconds { get; private set; }
    }
}