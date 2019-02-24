namespace FrizzyAdventure.Managers.Hud
{
    using FrizzyAdventure.Managers.ServiceLocator;

    internal sealed class HudManager
    {
        private readonly BaseServiceLocator _serviceLocator;

        public HudManager(BaseServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }
    }
}