namespace Game.Scripts.Core.Signals
{
    public class GameStateChangedSignal
    {
        public GameStateChangedSignal(GameState previousState, GameState currentState)
        {
            PreviousState = previousState;
            CurrentState = currentState;
        }

        public GameState PreviousState { get; private set; }
        public GameState CurrentState { get; private set; }
    }
}