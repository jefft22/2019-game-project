namespace RedRocket.FA
{
    using FrizzyAdventure.Constant;
    using FrizzyAdventure.Managers.Actor;
    using FrizzyAdventure.Managers.Actor.Block;
    using FrizzyAdventure.Managers.Actor.Model;
    using FrizzyAdventure.Managers.Actor.Player;
    using FrizzyAdventure.Managers.Actor.Slime;
    using FrizzyAdventure.Managers.Configuration;
    using FrizzyAdventure.Managers.Configuration.Model;
    using FrizzyAdventure.Managers.Controller;
    using FrizzyAdventure.Managers.Hud;
    using FrizzyAdventure.Managers.Map;
    using FrizzyAdventure.Managers.Renderer;
    using FrizzyAdventure.Managers.Resource;
    using FrizzyAdventure.Managers.Resource.Constant;
    using FrizzyAdventure.Managers.ServiceLocator;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System;

    internal class FrizzyAdventureGame : Game
    {
        private ActorManager _actorManager;

        private ConfigurationManager _configurationManager;

        private ControllerManager _controllerManager;

        private GameConfiguration _gameConfiguration;

        private readonly GraphicsDeviceManager _graphicsDeviceManager;

        private HudManager _hudManager;

        private MapManager _mapManager;

        private RendererManager _rendererManager;

        private ResourceManager _resourceManager;

        private readonly BaseServiceLocator _serviceLocator;

        private ActorManager ActorManager
            => _actorManager ?? (_actorManager = _serviceLocator.CreateActorManager());

        private ConfigurationManager ConfigurationManager
            => _configurationManager ?? (_configurationManager = _serviceLocator.CreateConfigurationManager());

        private ControllerManager ControllerManager
            => _controllerManager ?? (_controllerManager = _serviceLocator.CreateControllerManager());

        private GameConfiguration GameConfiguration
            => _gameConfiguration ?? (_gameConfiguration = ConfigurationManager.LoadGameConfiguration());

        private HudManager HudManager
            => _hudManager ?? (_hudManager = _serviceLocator.CreateHudManager());

        private MapManager MapManager
            => _mapManager ?? (_mapManager = _serviceLocator.CreateMapManager());

        private RendererManager RendererManager
            => _rendererManager ?? (_rendererManager = _serviceLocator.CreateRendererManager(_graphicsDeviceManager, ResourceManager));

        private ResourceManager ResourceManager
            => _resourceManager ?? (_resourceManager = _serviceLocator.CreateResourceManager(this.Content));

        public FrizzyAdventureGame(BaseServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;

            _graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = ResourceConstants.ContentDirectory;
            this.IsFixedTimeStep = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1d / 60d);
            this.IsMouseVisible = DefaultWindowConstants.DefaultMouseVisibility;
            _graphicsDeviceManager.PreferredBackBufferHeight = GameConfiguration.WindowHeight;
            _graphicsDeviceManager.PreferredBackBufferWidth = GameConfiguration.WindowWidth;
            this.Window.Title = DefaultWindowConstants.WindowTitle;
            this.Window.Position = new Point(GameConfiguration.WindowPositionX, GameConfiguration.WindowPositionY);
        }

        protected override void Initialize()
        {
            ResourceManager.LoadTexture(FrizzyAdventure.Managers.Resource.Model.TextureKey.Dungeon);
            ResourceManager.LoadTexture(FrizzyAdventure.Managers.Resource.Model.TextureKey.Frizzy);
            ResourceManager.LoadTexture(FrizzyAdventure.Managers.Resource.Model.TextureKey.GameplayHud);
            ResourceManager.LoadTexture(FrizzyAdventure.Managers.Resource.Model.TextureKey.Slime);

            BasicActorConstruction blockConstruction = new BasicActorConstruction()
            {
                X = 32,
                Y = 32,
                ActorConstructionType = BasicActorConstructionType.DungeonBlock_01
            };
            var block = new BlockActor(blockConstruction);
            ActorManager.AddActor(block);

            blockConstruction.X = 48;
            block = new BlockActor(blockConstruction);
            ActorManager.AddActor(block);

            blockConstruction.Y = 16;
            block = new BlockActor(blockConstruction);
            ActorManager.AddActor(block);

            blockConstruction.X = 80;
            blockConstruction.Y = 32;
            block = new BlockActor(blockConstruction);
            ActorManager.AddActor(block);

            BasicActorConstruction otherBlockConstruction = new BasicActorConstruction()
            {
                X = 32,
                Y = 48,
                ActorConstructionType = BasicActorConstructionType.DungeonBlock_03
            };
            block = new BlockActor(otherBlockConstruction);
            ActorManager.AddActor(block);

            otherBlockConstruction.X = 48;
            block = new BlockActor(otherBlockConstruction);
            ActorManager.AddActor(block);

            otherBlockConstruction.X = 64;
            block = new BlockActor(otherBlockConstruction);
            ActorManager.AddActor(block);

            otherBlockConstruction.Y = 32;
            block = new BlockActor(otherBlockConstruction);
            ActorManager.AddActor(block);

            otherBlockConstruction.Y = 16;
            block = new BlockActor(otherBlockConstruction);
            ActorManager.AddActor(block);

            otherBlockConstruction.Y = 0;
            block = new BlockActor(otherBlockConstruction);
            ActorManager.AddActor(block);

            otherBlockConstruction.X = 48;
            block = new BlockActor(otherBlockConstruction);
            ActorManager.AddActor(block);

            otherBlockConstruction.X = 32;
            block = new BlockActor(otherBlockConstruction);
            ActorManager.AddActor(block);

            otherBlockConstruction.X = 16;
            block = new BlockActor(otherBlockConstruction);
            ActorManager.AddActor(block);

            otherBlockConstruction.Y = 16;
            block = new BlockActor(otherBlockConstruction);
            ActorManager.AddActor(block);

            otherBlockConstruction.Y = 32;
            block = new BlockActor(otherBlockConstruction);
            ActorManager.AddActor(block);

            otherBlockConstruction.Y = 48;
            block = new BlockActor(otherBlockConstruction);
            ActorManager.AddActor(block);

            otherBlockConstruction.X = 32;
            otherBlockConstruction.Y = 16;
            block = new BlockActor(otherBlockConstruction);
            ActorManager.AddActor(block);

            var player = new PlayerActor(ActorManager, ControllerManager);
            ActorManager.AddActor(player);

            MapManager.SetCameraFocus(player);
            MapManager.SetMapSize(200, 160);

            var slimeConstruction = new BasicActorConstruction
            {
                ActorConstructionType = BasicActorConstructionType.SlimeActive,
                X = 32,
                Y = 64
            };
            var slime = new SlimeActor(ActorManager, slimeConstruction);
            ActorManager.AddActor(slime);
        }

        protected override void LoadContent()
        {
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            ControllerManager.UpdateControllerState();
            ActorManager.UpdateAllActors();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                GameConfiguration.WindowPositionX = this.Window.Position.X;
                GameConfiguration.WindowPositionY = this.Window.Position.Y;

                ConfigurationManager.SaveGameConfiguration(GameConfiguration);

                Exit();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            RendererManager.RenderFrame(MapManager.GetCameraPositionOnMap(), ActorManager.GetAllActorsRenderInfo());
        }
    }
}