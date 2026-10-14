using Game.Scripts.Core.Signals;
using Zenject;

namespace Game.Scripts.Core
{
    public class GameStateService : IGameStateService
    {
        private SignalBus _signalBus;

        public GameStateService(SignalBus signalBus)
        {
            _signalBus = signalBus;
            
            CurrentState = GameState.Loading;
        }
            
        public GameState CurrentState { get; private set; }

        public bool IsPlaying => CurrentState == GameState.Playing;
        public bool IsPaused => CurrentState == GameState.Paused;

        
        public void ChangeState(GameState newState)
        {
            if (CurrentState == newState)
                return;

            GameState previousState = CurrentState;
            CurrentState = newState;
            
            _signalBus.Fire(new GameStateChangedSignal(previousState, newState));
        }
    }
}