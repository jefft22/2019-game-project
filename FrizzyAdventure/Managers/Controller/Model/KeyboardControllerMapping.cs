namespace FrizzyAdventure.Managers.Controller.Model
{
    using Microsoft.Xna.Framework.Input;
    using FrizzyAdventure.Managers.Controller.Constant;

    internal sealed class KeyboardControllerMapping
    {
        public Keys AButton { get; set; } = DefaultKeyboardControllerConstants.DefaultAButtonKey;

        public Keys BButton { get; set; } = DefaultKeyboardControllerConstants.DefaultBButtonKey;

        public Keys DownButton { get; set; } = DefaultKeyboardControllerConstants.DefaultDownButtonKey;

        public Keys LeftButton { get; set; } = DefaultKeyboardControllerConstants.DefaultLeftButtonKey;

        public Keys RightButton { get; set; } = DefaultKeyboardControllerConstants.DefaultRightButtonKey;

        public Keys SelectButton { get; set; } = DefaultKeyboardControllerConstants.DefaultSelectButtonKey;

        public Keys StartButton { get; set; } = DefaultKeyboardControllerConstants.DefaultStartButtonKey;

        public Keys UpButton { get; set; } = DefaultKeyboardControllerConstants.DefaultUpButtonKey;
    }
}