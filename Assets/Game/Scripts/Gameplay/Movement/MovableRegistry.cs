using System.Collections.Generic;

namespace Game.Scripts.Gameplay.Movement
{
    public class MovableRegistry
    {
        private HashSet<IMovable> _movables;
        
        public IReadOnlyCollection<IMovable> Movables => _movables;
        
        public void Register(IMovable movable)
        {
            _movables.Add(movable);
        }
    }
}