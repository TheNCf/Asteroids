namespace Game.Scripts.Core
{
    public class GameStateChanger
    {
        private IGameStateService _gameStateService;
        
        public GameStateChanger(IGameStateService gameStateService)
        {
            _gameStateService = gameStateService;
        }

        public void StartGame()
        {
            _gameStateService.ChangeState(GameState.Playing);
        }

        public void PauseGame()
        {
            if (_gameStateService.IsPlaying == false)
                return;
            
            _gameStateService.ChangeState(GameState.Paused);
        }

        public void ResumeGame()
        {
            if (_gameStateService.IsPaused == false)
                return;
            
            _gameStateService.ChangeState(GameState.Playing);
        }

        public void StopGame()
        {
            _gameStateService.ChangeState(GameState.GameOver);
        }
    }
}