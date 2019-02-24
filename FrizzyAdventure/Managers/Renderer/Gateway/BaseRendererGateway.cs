namespace FrizzyAdventure.Managers.Renderer.Gateway
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using FrizzyAdventure.Managers.Resource;
    using System.Collections.Generic;
    using FrizzyAdventure.Managers.Actor.Model;

    internal abstract class BaseRendererGateway
    {
        protected readonly GraphicsDeviceManager _graphicsDeviceManager;

        protected readonly ResourceManager _resourceManager;

        private SpriteBatch _spriteBatch;

        protected GraphicsDevice GraphicsDevice
            => _graphicsDeviceManager.GraphicsDevice;

        protected SpriteBatch SpriteBatch
            => _spriteBatch ?? (_spriteBatch = new SpriteBatch(GraphicsDevice));

        public BaseRendererGateway(GraphicsDeviceManager graphicsDeviceManager, ResourceManager resourceManager)
        {
            _graphicsDeviceManager = graphicsDeviceManager;
            _resourceManager = resourceManager;
        }

        public void RenderFrame(Vector2 cameraPosition, IEnumerable<IActorRenderInfo> actorRenderInfos)
            => RenderFrameCore(cameraPosition, actorRenderInfos);

        protected abstract void RenderFrameCore(Vector2 cameraPosition, IEnumerable<IActorRenderInfo> actorRenderInfos);
    }
}