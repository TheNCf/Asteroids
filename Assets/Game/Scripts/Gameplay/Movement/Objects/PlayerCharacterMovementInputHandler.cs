using Game.Scripts.Core.Input;
using Game.Scripts.Gameplay.Configs;
using Game.Scripts.Gameplay.Views;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.Movement.Objects
{
    public class PlayerCharacterMovementInputHandler : ITickable
    {
        private readonly PlayerCharacterMovement _playerCharacterMovement;
        private readonly PlayerCharacterView _playerCharacterView;
        private readonly PlayerCharacterConfig _playerCharacterConfig;
        private readonly IInputService _inputService;

        public PlayerCharacterMovementInputHandler(
            PlayerCharacterMovement playerCharacterMovement, 
            IInputService inputService, 
            PlayerCharacterView playerCharacterView, 
            PlayerCharacterConfig playerCharacterConfig)
        {
            _playerCharacterMovement = playerCharacterMovement;
            _inputService = inputService;
            _playerCharacterView = playerCharacterView;
            _playerCharacterConfig = playerCharacterConfig;
        }
        
        public void Tick()
        {
            HandleRotation();
            HandleMovement();
        }

        private void HandleRotation()
        {
            if (_inputService.MovementInput.x == 0)
                return;
            
            float angle = _inputService.MovementInput.x * _playerCharacterConfig.RotationSpeed * Time.deltaTime * -1;
            _playerCharacterMovement.Rotate(angle);
        }

        private void HandleMovement()
        {
            if (_inputService.MovementInput.y == 0)
                return;
            
            Vector2 addedVelocity = _playerCharacterView.transform.right * 
                                    (_inputService.MovementInput.y * _playerCharacterConfig.ThrustForce * Time.deltaTime);
            
            _playerCharacterMovement.ChangeVelocity(addedVelocity + _playerCharacterMovement.Velocity);
        }
    }
}