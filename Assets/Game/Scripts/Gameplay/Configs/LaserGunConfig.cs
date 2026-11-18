namespace Game.Scripts.Gameplay.Configs
{
    public class LaserGunConfig
    {
        public LaserGunConfig(float reloadTime, float maxAmount)
        {
            ReloadTime = reloadTime;
            MaxAmount = maxAmount;
        }

        public float ReloadTime { get; private set; }
        public float MaxAmount { get; private set; }
    }
}