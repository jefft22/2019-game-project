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

    internal abstract class BaseServiceLocator
    {
        public ActorManager CreateActorManager()
            => CreateActorManagerCore();

        public BaseConfigurationGateway CreateConfigurationGateway()
            => CreateConfigurationGatewayCore();

        public ConfigurationManager CreateConfigurationManager()
            => CreateConfigurationManagerCore();

        public BaseControllerGateway CreateKeyboardControllerGateway(KeyboardControllerMapping keyboardControllerMapping)
            => CreateKeyboardControllerGatewayCore(keyboardControllerMapping);

        public ControllerManager CreateControllerManager()
            => CreateControllerManagerCore();

        public GameState CreateGameState()
            => CreateGameStateCore();

        public GameStateManager CreateGameStateManager()
            => CreateGameStateManagerCore();

        public HudGateway CreateHudGateway()
            => CreateHudGatewayCore();

        public HudManager CreateHudManager()
            => CreateHudManagerCore();

        public MapGateway CreateMapGateway()
            => CreateMapGatewayCore();

        public MapManager CreateMapManager()
            => CreateMapManagerCore();

        public RendererManager CreateRendererManager(GraphicsDeviceManager graphicsDeviceManager, ResourceManager resourceManager)
            => CreateRendererManagerCore(graphicsDeviceManager, resourceManager);

        public BaseRendererGateway CreateRendererGateway(GraphicsDeviceManager graphicsDeviceManager, ResourceManager resourceManager)
            => CreateRendererGatewayCore(graphicsDeviceManager, resourceManager);

        public BaseResourceGateway CreateResourceGateway(ContentManager contentManager)
            => CreateResourceGatewayCore(contentManager);

        public ResourceManager CreateResourceManager(ContentManager contentManager)
            => CreateResourceManagerCore(contentManager);

        protected abstract ActorManager CreateActorManagerCore();

        protected abstract BaseConfigurationGateway CreateConfigurationGatewayCore();

        protected abstract ConfigurationManager CreateConfigurationManagerCore();

        protected abstract BaseControllerGateway CreateKeyboardControllerGatewayCore(KeyboardControllerMapping keyboardControllerMapping);

        protected abstract ControllerManager CreateControllerManagerCore();

        protected abstract GameState CreateGameStateCore();

        protected abstract GameStateManager CreateGameStateManagerCore();

        protected abstract HudGateway CreateHudGatewayCore();

        protected abstract HudManager CreateHudManagerCore();

        protected abstract MapGateway CreateMapGatewayCore();

        protected abstract MapManager CreateMapManagerCore();

        protected abstract RendererManager CreateRendererManagerCore(GraphicsDeviceManager graphicsDeviceManager, ResourceManager resourceManager);

        protected abstract BaseRendererGateway CreateRendererGatewayCore(GraphicsDeviceManager graphicsDeviceManager, ResourceManager resourceManager);

        protected abstract BaseResourceGateway CreateResourceGatewayCore(ContentManager contentManager);

        protected abstract ResourceManager CreateResourceManagerCore(ContentManager contentManager);
    }
}