namespace FrizzyAdventure.Managers.Controller.Model
{
    internal sealed class ControllerState
    {
        public bool AButtonIsPressed { get; set; } = false;

        public bool AButtonJustPressed { get; set; } = false;

        public bool BButtonIsPressed { get; set; } = false;

        public bool BButtonJustPressed { get; set; } = false;

        public bool DownButtonIsPressed { get; set; } = false;

        public bool DownButtonJustPressed { get; set; } = false;

        public bool LeftButtonIsPressed { get; set; } = false;

        public bool LeftButtonJustPressed { get; set; } = false;

        public bool RightButtonIsPressed { get; set; } = false;

        public bool RightButtonJustPressed { get; set; } = false;

        public bool SelectButtonIsPressed { get; set; } = false;

        public bool SelectButtonJustPressed { get; set; } = false;

        public bool StartButtonIsPressed { get; set; } = false;

        public bool StartButtonJustPressed { get; set; } = false;

        public bool UpButtonIsPressed { get; set; } = false;

        public bool UpButtonJustPressed { get; set; } = false;
    }
}