namespace FrizzyAdventure.Managers.Controller.Gateway
{
    using Microsoft.Xna.Framework.Input;
    using FrizzyAdventure.Managers.Controller.Model;

    internal sealed class KeyboardControllerGateway : BaseControllerGateway
    {
        private readonly KeyboardControllerMapping _keyboardControllerMapping;

        public KeyboardControllerGateway(KeyboardControllerMapping keyboardControllerMapping) : base()
        {
            _keyboardControllerMapping = keyboardControllerMapping;
        }

        protected override ControllerState GetControllerStateCore()
            => ControllerState;

        protected override void UpdateControllerStateCore()
        {
            var keyboardState = Keyboard.GetState();

            ControllerState.AButtonJustPressed = WasButtonJustPressed(keyboardState.IsKeyDown(_keyboardControllerMapping.AButton), ControllerState.AButtonIsPressed);
            ControllerState.AButtonIsPressed = keyboardState.IsKeyDown(_keyboardControllerMapping.AButton);

            ControllerState.BButtonJustPressed = WasButtonJustPressed(keyboardState.IsKeyDown(_keyboardControllerMapping.BButton), ControllerState.BButtonIsPressed);
            ControllerState.BButtonIsPressed = keyboardState.IsKeyDown(_keyboardControllerMapping.BButton);

            ControllerState.DownButtonJustPressed = WasButtonJustPressed(keyboardState.IsKeyDown(_keyboardControllerMapping.DownButton), ControllerState.DownButtonIsPressed);
            ControllerState.DownButtonIsPressed = keyboardState.IsKeyDown(_keyboardControllerMapping.DownButton);

            ControllerState.LeftButtonJustPressed = WasButtonJustPressed(keyboardState.IsKeyDown(_keyboardControllerMapping.LeftButton), ControllerState.LeftButtonIsPressed);
            ControllerState.LeftButtonIsPressed = keyboardState.IsKeyDown(_keyboardControllerMapping.LeftButton);

            ControllerState.RightButtonJustPressed = WasButtonJustPressed(keyboardState.IsKeyDown(_keyboardControllerMapping.RightButton), ControllerState.RightButtonIsPressed);
            ControllerState.RightButtonIsPressed = keyboardState.IsKeyDown(_keyboardControllerMapping.RightButton);

            ControllerState.SelectButtonJustPressed = WasButtonJustPressed(keyboardState.IsKeyDown(_keyboardControllerMapping.SelectButton), ControllerState.SelectButtonIsPressed);
            ControllerState.SelectButtonIsPressed = keyboardState.IsKeyDown(_keyboardControllerMapping.SelectButton);

            ControllerState.StartButtonJustPressed = WasButtonJustPressed(keyboardState.IsKeyDown(_keyboardControllerMapping.StartButton), ControllerState.StartButtonIsPressed);
            ControllerState.StartButtonIsPressed = keyboardState.IsKeyDown(_keyboardControllerMapping.StartButton);

            ControllerState.UpButtonJustPressed = WasButtonJustPressed(keyboardState.IsKeyDown(_keyboardControllerMapping.UpButton), ControllerState.UpButtonIsPressed);
            ControllerState.UpButtonIsPressed = keyboardState.IsKeyDown(_keyboardControllerMapping.UpButton);
        }

        private bool WasButtonJustPressed(bool currentStateOfKey, bool lastStateOfKey)
            => (currentStateOfKey && !lastStateOfKey);
    }
}