namespace FrizzyAdventure.Managers.Renderer
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using FrizzyAdventure.Managers.Actor.Model;
    using FrizzyAdventure.Managers.Renderer.Gateway;
    using FrizzyAdventure.Managers.Resource;
    using FrizzyAdventure.Managers.ServiceLocator;
    using System.Collections.Generic;

    internal sealed class RendererManager
    {
        private readonly GraphicsDeviceManager _graphicsDeviceManager;

        private BaseRendererGateway _rendererGateway;

        private readonly ResourceManager _resourceManager;

        private readonly BaseServiceLocator _serviceLocator;

        private BaseRendererGateway RendererGateway
            => _rendererGateway ?? (_rendererGateway = _serviceLocator.CreateRendererGateway(_graphicsDeviceManager, _resourceManager));

        public RendererManager(BaseServiceLocator serviceLocator, GraphicsDeviceManager graphicsDeviceManager, ResourceManager resourceManager)
        {
            _graphicsDeviceManager = graphicsDeviceManager;
            _resourceManager = resourceManager;
            _serviceLocator = serviceLocator;
        }

        public void RenderFrame(Vector2 cameraPosition, IEnumerable<IActorRenderInfo> actorRenderInfos)
            => RendererGateway.RenderFrame(cameraPosition, actorRenderInfos);
    }
}