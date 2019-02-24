namespace FrizzyAdventure.Managers.Map.Gateway
{
    using FrizzyAdventure.Managers.Renderer.Constant;
    using FrizzyAdventure.Managers.Actor.Model;
    using Microsoft.Xna.Framework;

    internal sealed class MapGateway
    {
        private Vector2 _cameraPosition = new Vector2();

        private IActorPhysicalInfo _focusActor;

        private Rectangle _mapSize = new Rectangle();

        public MapGateway()
        {
        }

        public Vector2 GetCameraPositionOnMap()
        {
            UpdateCameraPositionOnMap();
            return _cameraPosition;
        }

        public void SetCameraFocus(IActorPhysicalInfo focusActor)
        {
            _focusActor = focusActor;
        }

        public void SetMapSize(int width, int height)
        {
            _mapSize.Height = height;
            _mapSize.Width = width;
        }

        private void UpdateCameraPositionOnMap()
        {
            float centerFocusX = (_focusActor.X1 + _focusActor.X2) / 2;
            float centerFocusY = (_focusActor.Y1 + _focusActor.Y2) / 2;

            float leftCamera = ((centerFocusX - 80) < 0) ? 0 : (centerFocusX - 80);
            float topCamera = ((centerFocusY - 64) < 0) ? 0 : (centerFocusY - 64);

            if ((leftCamera + (RendererConstants.GameBufferWidth / 2)) > _mapSize.Width)
            {
                leftCamera = _mapSize.Width - (RendererConstants.GameBufferWidth / 2);
            }

            if ((topCamera + (RendererConstants.GameBufferHeight / 2)) > _mapSize.Height)
            {
                topCamera = _mapSize.Height - (RendererConstants.GameBufferHeight / 2);
            }

            _cameraPosition.X = leftCamera;
            _cameraPosition.Y = topCamera;
        }
    }
}