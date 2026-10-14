namespace Game.Scripts.Core
{
    public interface IGameStateService
    {
        GameState CurrentState { get; }
        
        bool IsPlaying { get; }
        bool IsPaused { get; }

        void ChangeState(GameState newState);
    }
}