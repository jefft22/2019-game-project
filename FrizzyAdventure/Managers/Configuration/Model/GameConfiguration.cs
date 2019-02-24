namespace FrizzyAdventure.Managers.Configuration.Model
{
    using Newtonsoft.Json;
    using FrizzyAdventure.Constant;
    using System;

    [Serializable]
    internal sealed class GameConfiguration
    {
        [JsonProperty("isMouseVisible")]
        public bool IsMouseVisible { get; set; } = DefaultWindowConstants.DefaultMouseVisibility;

        [JsonProperty("windowHeight")]
        public int WindowHeight { get; set; } = DefaultWindowConstants.DefaultWindowHeight;

        [JsonProperty("windowPositionX")]
        public int WindowPositionX { get; set; } = 0;

        [JsonProperty("windowPositionY")]
        public int WindowPositionY { get; set; } = 0;

        [JsonProperty("windowWidth")]
        public int WindowWidth { get; set; } = DefaultWindowConstants.DefaultWindowWidth;
    }
}