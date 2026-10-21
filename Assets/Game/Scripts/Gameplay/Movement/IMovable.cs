using UnityEngine;

namespace Game.Scripts.Gameplay.Movement
{
    public interface IMovable
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; }

        void Move(Vector2 delta);
        void Move(float deltaX = 0, float deltaY = 0);
    }
}