namespace FrizzyAdventure.Managers.Resource.Gateway
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using FrizzyAdventure.Managers.Resource.Model;

    internal abstract class BaseResourceGateway
    {
        protected readonly ContentManager _contentManager;

        public BaseResourceGateway(ContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public Texture2D GetTexture(TextureKey textureKey)
            => GetTextureCore(textureKey);

        public void LoadTexture(TextureKey textureKey)
            => LoadTextureCore(textureKey);

        public void UnloadAllTextures()
            => UnloadAllTexturesCore();

        public void UnloadTexture(TextureKey textureKey)
            => UnloadTexture(textureKey);

        protected abstract Texture2D GetTextureCore(TextureKey textureKey);

        protected abstract void LoadTextureCore(TextureKey textureKey);

        protected abstract void UnloadAllTexturesCore();

        protected abstract void UnloadTextureCore(TextureKey textureKey);
    }
}