namespace FrizzyAdventure.Managers.GameState
{
    using FrizzyAdventure.Managers.GameState.Gateway;
    using FrizzyAdventure.Managers.ServiceLocator;

    internal sealed class GameStateManager
    {
        private GameState _gameState;

        private readonly BaseServiceLocator _serviceLocator;

        private GameState GameState
            => _gameState ?? (_gameState = _serviceLocator.CreateGameState());

        public GameStateManager(BaseServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }
    }
}