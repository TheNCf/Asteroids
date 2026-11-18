namespace Game.Scripts.Gameplay.Configs
{
    public class MachineGunConfig
    {
        public MachineGunConfig(float reloadTime)
        {
            ReloadTime = reloadTime;
        }
        
        public float ReloadTime { get; private set; }
    }
}