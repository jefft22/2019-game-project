namespace FrizzyAdventure.Managers.Map
{
    using FrizzyAdventure.Managers.Actor.Model;
    using FrizzyAdventure.Managers.Map.Gateway;
    using FrizzyAdventure.Managers.ServiceLocator;
    using Microsoft.Xna.Framework;

    internal sealed class MapManager
    {
        private MapGateway _mapGateway;

        private readonly BaseServiceLocator _serviceLocator;

        private MapGateway MapGateway
            => _mapGateway ?? (_mapGateway = _serviceLocator.CreateMapGateway());

        public MapManager(BaseServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public Vector2 GetCameraPositionOnMap()
            => MapGateway.GetCameraPositionOnMap();

        public void SetCameraFocus(IActorPhysicalInfo focusActor)
            => MapGateway.SetCameraFocus(focusActor);

        public void SetMapSize(int width, int height)
            => MapGateway.SetMapSize(width, height);
    }
}