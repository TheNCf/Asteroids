using Game.Scripts.Core.Input;
using Game.Scripts.Gameplay.Weapons;

namespace Game.Scripts.Gameplay.Player
{
    public class PlayerCharacterWeaponInputHandler
    {
        private readonly IInputService _inputService;
        
        private readonly MachineGun _machineGun;
        private readonly LaserGun _laserGun;

        public PlayerCharacterWeaponInputHandler(IInputService inputService, MachineGun machineGun, LaserGun laserGun)
        {
            _inputService = inputService;
            _machineGun = machineGun;
            _laserGun = laserGun;

            _inputService.BulletButtonPressed += OnBulletButtonPressed;
            _inputService.LaserButtonPressed += OnLaserButtonPressed;
        }

        private void OnBulletButtonPressed()
        {
            _machineGun.Fire();
        }

        private void OnLaserButtonPressed()
        {
            _laserGun.Fire();
        }
    }
}