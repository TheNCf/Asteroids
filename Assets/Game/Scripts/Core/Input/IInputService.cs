using System;
using UnityEngine;

namespace Game.Scripts.Core.Input
{
    public interface IInputService
    {
        Vector2 MovementInput { get; }
        
        event Action BulletButtonPressed;
        event Action LaserButtonPressed;
    }
}