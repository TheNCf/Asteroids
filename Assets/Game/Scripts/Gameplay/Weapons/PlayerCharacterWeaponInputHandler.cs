using Game.Scripts.Core.Input;

namespace Game.Scripts.Gameplay.Weapons
{
    public class PlayerCharacterWeaponInputHandler
    {
        private IInputService _inputService;
        
        private MachineGun _machineGun;

        public PlayerCharacterWeaponInputHandler(MachineGun machineGun, IInputService inputService)
        {
            _inputService = inputService;
            _machineGun = machineGun;

            _inputService.BulletButtonPressed += OnBulletButtonPressed;
        }

        private void OnBulletButtonPressed()
        {
            _machineGun.Fire();
        }
    }
}