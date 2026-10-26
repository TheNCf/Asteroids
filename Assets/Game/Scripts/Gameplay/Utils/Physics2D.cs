using Game.Scripts.Gameplay.Movement;
using UnityEngine;

namespace Game.Scripts.Gameplay.Utils
{
    public static class Physics2D
    {
        public static void CalculateBounce(IMovable obj1, IMovable obj2)
        {
            Vector2 normal = (obj2.Position - obj1.Position).normalized;
    
            Vector2 relativeVelocity = obj1.Velocity - obj2.Velocity;
            float velAlongNormal = Vector2.Dot(relativeVelocity, normal);

            Vector2 impulse = normal * velAlongNormal;

            obj1.ChangeVelocity(obj1.Velocity - impulse);
            obj2.ChangeVelocity(obj2.Velocity + impulse);
        }
    }
}