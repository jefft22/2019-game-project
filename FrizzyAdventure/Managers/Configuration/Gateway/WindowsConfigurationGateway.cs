namespace FrizzyAdventure.Managers.Configuration.Gateway
{
    using Newtonsoft.Json;
    using FrizzyAdventure.Managers.Configuration.Constant;
    using FrizzyAdventure.Managers.Configuration.Model;
    using System;
    using System.IO;

    internal sealed class WindowsConfigurationGateway : BaseConfigurationGateway
    {
        private readonly string _configurationFilePath;

        private string ControllerConfigurationUri
            => Path.Combine(_configurationFilePath, DefaultConfigurationConstants.ControllerConfigurationFileName);

        private string GameConfigurationUri
            => Path.Combine(_configurationFilePath, DefaultConfigurationConstants.GameConfigurationFileName);

        public WindowsConfigurationGateway() : base()
        {
            _configurationFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }

        protected override GameConfiguration LoadGameConfigurationCore()
        {
            if (!File.Exists(GameConfigurationUri))
            {
                return new GameConfiguration();
            }

            string jsonData;

            using (var streamReader = new StreamReader(GameConfigurationUri))
            {
                jsonData = streamReader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<GameConfiguration>(jsonData);
        }

        protected override void SaveGameConfigurationCore(GameConfiguration gameConfiguration)
        {
            using (var streamWriter = new StreamWriter(GameConfigurationUri, false))
            {
                var jsonData = JsonConvert.SerializeObject(gameConfiguration);
                streamWriter.Write(jsonData);
            }
        }
    }
}