namespace FrizzyAdventure.Managers.Resource.Gateway
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using FrizzyAdventure.Managers.Resource.Model;
    using System.Collections.Generic;
    using static FrizzyAdventure.Managers.Resource.Constant.TextureResourceConstants;

    internal sealed class WindowsResourceManager : BaseResourceGateway
    {
        private Dictionary<TextureKey, Texture2D> _textures = new Dictionary<TextureKey, Texture2D>();

        public WindowsResourceManager(ContentManager contentManager) : base(contentManager)
        {
        }

        protected override Texture2D GetTextureCore(TextureKey textureKey)
        {
            if (!_textures.ContainsKey(textureKey))
            {
                LoadTexture(textureKey);
            }

            return _textures[textureKey];
        }

        protected override void LoadTextureCore(TextureKey textureKey)
        {
            if (!_textures.ContainsKey(textureKey))
            {
                var textureString = TextureLookupTable[textureKey];
                var texture = _contentManager.Load<Texture2D>(textureString);
                _textures.Add(textureKey, texture);
            }
        }

        protected override void UnloadAllTexturesCore()
        {
            foreach (var texture in _textures)
            {
                UnloadTexture(texture.Key);
            }
        }

        protected override void UnloadTextureCore(TextureKey textureKey)
        {
            if (_textures.ContainsKey(textureKey))
            {
                _textures[textureKey].Dispose();
                _textures.Remove(textureKey);
            }
        }
    }
}