namespace FrizzyAdventure.Managers.ServiceLocator
{
    using FrizzyAdventure.Managers.Actor;
    using FrizzyAdventure.Managers.Configuration;
    using FrizzyAdventure.Managers.Configuration.Gateway;
    using FrizzyAdventure.Managers.Controller;
    using FrizzyAdventure.Managers.Controller.Gateway;
    using FrizzyAdventure.Managers.Controller.Model;
    using FrizzyAdventure.Managers.GameState;
    using FrizzyAdventure.Managers.GameState.Gateway;
    using FrizzyAdventure.Managers.Hud;
    using FrizzyAdventure.Managers.Hud.Gateway;
    using FrizzyAdventure.Managers.Map;
    using FrizzyAdventure.Managers.Map.Gateway;
    using FrizzyAdventure.Managers.Renderer;
    using FrizzyAdventure.Managers.Renderer.Gateway;
    using FrizzyAdventure.Managers.Resource;
    using FrizzyAdventure.Managers.Resource.Gateway;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;

    internal sealed class WindowsServiceLocator : BaseServiceLocator
    {
        protected override ActorManager CreateActorManagerCore()
            => new ActorManager();

        protected override BaseConfigurationGateway CreateConfigurationGatewayCore()
            => new WindowsConfigurationGateway();

        protected override ConfigurationManager CreateConfigurationManagerCore()
            => new ConfigurationManager(this);

        protected override ControllerManager CreateControllerManagerCore()
            => new ControllerManager(this, new KeyboardControllerMapping());

        protected override GameState CreateGameStateCore()
            => new GameState();

        protected override GameStateManager CreateGameStateManagerCore()
            => new GameStateManager(this);

        protected override HudGateway CreateHudGatewayCore()
            => new HudGateway();

        protected override HudManager CreateHudManagerCore()
            => new HudManager(this);

        protected override BaseControllerGateway CreateKeyboardControllerGatewayCore(KeyboardControllerMapping keyboardControllerMapping)
            => new KeyboardControllerGateway(keyboardControllerMapping);

        protected override MapGateway CreateMapGatewayCore()
            => new MapGateway();

        protected override MapManager CreateMapManagerCore()
            => new MapManager(this);

        protected override BaseRendererGateway CreateRendererGatewayCore(GraphicsDeviceManager graphicsDeviceManager, ResourceManager resourceManager)
            => new WindowsRendererGateway(graphicsDeviceManager, resourceManager);

        protected override RendererManager CreateRendererManagerCore(GraphicsDeviceManager graphicsDeviceManager, ResourceManager resourceManager)
            => new RendererManager(this, graphicsDeviceManager, resourceManager);

        protected override BaseResourceGateway CreateResourceGatewayCore(ContentManager contentManager)
            => new WindowsResourceManager(contentManager);

        protected override ResourceManager CreateResourceManagerCore(ContentManager contentManager)
            => new ResourceManager(this, contentManager);
    }
}