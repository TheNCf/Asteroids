namespace Game.Scripts.Gameplay.Configs
{
    public class LaserGunConfig
    {
        public LaserGunConfig(float reloadTime, int maxAmount, float cooldown)
        {
            ReloadTime = reloadTime;
            MaxAmount = maxAmount;
            Cooldown = cooldown;
        }

        public float ReloadTime { get; private set; }
        public int MaxAmount { get; private set; }
        public float Cooldown { get; private set; }
    }
}