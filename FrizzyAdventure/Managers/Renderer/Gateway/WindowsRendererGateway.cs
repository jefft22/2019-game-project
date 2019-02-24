namespace FrizzyAdventure.Managers.Renderer.Gateway
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using FrizzyAdventure.Managers.Actor.Model;
    using FrizzyAdventure.Managers.Resource;
    using FrizzyAdventure.Managers.Resource.Model;
    using System.Collections.Generic;
    using static FrizzyAdventure.Managers.Renderer.Constant.RendererConstants;

    internal sealed class WindowsRendererGateway : BaseRendererGateway
    {
        private Vector2 _drawActorRenderVector = new Vector2();

        private RenderTarget2D _gameBuffer;

        private RenderTarget2D GameBuffer
            => _gameBuffer ?? (_gameBuffer = new RenderTarget2D(GraphicsDevice, GameBufferWidth, GameBufferHeight));

        public WindowsRendererGateway(GraphicsDeviceManager graphicsDeviceManager, ResourceManager resourceManager) : base(graphicsDeviceManager, resourceManager)
        {
        }

        protected override void RenderFrameCore(Vector2 cameraPosition, IEnumerable<IActorRenderInfo> actorRenderInfos)
        {
            GraphicsDevice.SetRenderTarget(GameBuffer);
            GraphicsDevice.Clear(Color.HotPink);

            SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);

            foreach (var actor in actorRenderInfos)
            {
                DrawActor(actor, SpriteBatch, cameraPosition);
            }

            SpriteBatch.End();

            SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);
            RenderGameplayHud(SpriteBatch);
            SpriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);
            SpriteBatch.Draw(GameBuffer, new Rectangle(0, 0, 800, 720), Color.White);
            SpriteBatch.End();
        }

        private void DrawActor(IActorRenderInfo actor, SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            _drawActorRenderVector.X = actor.RenderVector.X - cameraPosition.X;
            _drawActorRenderVector.Y = actor.RenderVector.Y - cameraPosition.Y;

            switch (actor.ZSort)
            {
                case ActorZSort.AlwaysOnBottom:
                    SpriteBatch.Draw(_resourceManager.GetTexture(actor.TextureKey), _drawActorRenderVector, actor.TextureClipping, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
                    break;

                case ActorZSort.AlwaysOnTop:
                    SpriteBatch.Draw(_resourceManager.GetTexture(actor.TextureKey), _drawActorRenderVector, actor.TextureClipping, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1.0f);
                    break;

                case ActorZSort.YSorted:
                    float zDepth = (_drawActorRenderVector.Y / 320f);

                    if (zDepth < 0.01f)
                    {
                        zDepth = 0.01f;
                    }
                    if (zDepth > 0.99f)
                    {
                        zDepth = 0.99f;
                    }

                    SpriteBatch.Draw(_resourceManager.GetTexture(actor.TextureKey), _drawActorRenderVector, actor.TextureClipping, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, zDepth);
                    break;
            }
        }

        private void RenderGameplayHud(SpriteBatch spriteBatch)
        {
            SpriteBatch.Draw(_resourceManager.GetTexture(TextureKey.GameplayHud), new Vector2(0, 128), new Rectangle(0, 0, 160, 16), Color.White);
        }
    }
}