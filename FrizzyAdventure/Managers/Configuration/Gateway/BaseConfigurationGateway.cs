namespace FrizzyAdventure.Managers.Configuration.Gateway
{
    using FrizzyAdventure.Managers.Configuration.Model;

    internal abstract class BaseConfigurationGateway
    {
        public BaseConfigurationGateway()
        {
        }

        public GameConfiguration LoadGameConfiguration()
            => LoadGameConfigurationCore();

        public void SaveGameConfiguration(GameConfiguration gameConfiguration)
            => SaveGameConfigurationCore(gameConfiguration);

        protected abstract GameConfiguration LoadGameConfigurationCore();

        protected abstract void SaveGameConfigurationCore(GameConfiguration gameConfiguration);
    }
}