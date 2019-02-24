namespace FrizzyAdventure.Managers.Configuration
{
    using FrizzyAdventure.Managers.Configuration.Gateway;
    using FrizzyAdventure.Managers.Configuration.Model;
    using FrizzyAdventure.Managers.ServiceLocator;

    internal sealed class ConfigurationManager
    {
        private BaseConfigurationGateway _configurationGateway;

        private readonly BaseServiceLocator _serviceLocator;

        private BaseConfigurationGateway ConfigurationGateway
            => _configurationGateway ?? (_configurationGateway = _serviceLocator.CreateConfigurationGateway());

        public ConfigurationManager(BaseServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public GameConfiguration LoadGameConfiguration()
            => ConfigurationGateway.LoadGameConfiguration();

        public void SaveGameConfiguration(GameConfiguration gameConfiguration)
            => ConfigurationGateway.SaveGameConfiguration(gameConfiguration);
    }
}