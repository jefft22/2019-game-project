namespace FrizzyAdventure.Managers.Controller.Gateway
{
    using FrizzyAdventure.Managers.Controller.Model;

    internal abstract class BaseControllerGateway
    {
        protected ControllerState ControllerState { get; } = new ControllerState();

        public BaseControllerGateway()
        {
        }

        public ControllerState GetControllerState()
            => GetControllerStateCore();

        public void UpdateControllerState()
            => UpdateControllerStateCore();

        protected abstract ControllerState GetControllerStateCore();

        protected abstract void UpdateControllerStateCore();
    }
}