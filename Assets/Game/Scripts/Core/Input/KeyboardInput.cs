using System;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Core.Input
{
    public class KeyboardInput : IInputService, ITickable
    {
        public Vector2 MovementInput { get; private set; }
        
        public event Action BulletButtonPressed;
        public event Action LaserButtonPressed;


        public void Tick()
        {
            float negHorizontal = UnityEngine.Input.GetKey(KeyCode.A) ? -1f : 0f;
            float posHorizontal = UnityEngine.Input.GetKey(KeyCode.D) ? 1f : 0f;
            float negVertical = UnityEngine.Input.GetKey(KeyCode.S) ? -1f : 0f;
            float posVertical = UnityEngine.Input.GetKey(KeyCode.W) ? 1f : 0f;

            MovementInput = new Vector2(posHorizontal + negHorizontal, posVertical + negVertical);
            
            if (UnityEngine.Input.GetMouseButtonDown(0))
                BulletButtonPressed?.Invoke();
            
            if (UnityEngine.Input.GetMouseButtonDown(1))
                LaserButtonPressed?.Invoke();
        }
    }
}