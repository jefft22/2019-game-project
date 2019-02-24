namespace FrizzyAdventure.Managers.Controller
{
    using FrizzyAdventure.Managers.Controller.Gateway;
    using FrizzyAdventure.Managers.Controller.Model;
    using FrizzyAdventure.Managers.ServiceLocator;

    internal sealed class ControllerManager
    {
        private BaseControllerGateway _keyboardControllerGateway;

        private readonly KeyboardControllerMapping _keyboardControllerMapping;

        private readonly BaseServiceLocator _serviceLocator;

        private BaseControllerGateway KeyboardControllerGateway
            => _keyboardControllerGateway ?? (_keyboardControllerGateway = _serviceLocator.CreateKeyboardControllerGateway(_keyboardControllerMapping));

        public ControllerManager(BaseServiceLocator serviceLocator, KeyboardControllerMapping keyboardControllerMapping)
        {
            _keyboardControllerMapping = keyboardControllerMapping;
            _serviceLocator = serviceLocator;
        }

        public ControllerState GetControllerState()
            => KeyboardControllerGateway.GetControllerState();

        public void UpdateControllerState()
            => KeyboardControllerGateway.UpdateControllerState();
    }
}