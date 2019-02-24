namespace FrizzyAdventure.Managers.Resource
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using FrizzyAdventure.Managers.Resource.Gateway;
    using FrizzyAdventure.Managers.Resource.Model;
    using FrizzyAdventure.Managers.ServiceLocator;

    internal sealed class ResourceManager
    {
        private readonly ContentManager _contentManager;

        private readonly BaseServiceLocator _serviceLocator;

        private BaseResourceGateway _resourceGateway;

        private BaseResourceGateway ResourceGateway
            => _resourceGateway ?? (_resourceGateway = _serviceLocator.CreateResourceGateway(_contentManager));

        public ResourceManager(BaseServiceLocator serviceLocator, ContentManager contentManager)
        {
            _contentManager = contentManager;
            _serviceLocator = serviceLocator;
        }

        public Texture2D GetTexture(TextureKey textureKey)
            => ResourceGateway.GetTexture(textureKey);

        public void LoadTexture(TextureKey textureKey)
            => ResourceGateway.LoadTexture(textureKey);

        public void UnloadAllExtures()
            => ResourceGateway.UnloadAllTextures();

        public void UnloadTexture(TextureKey textureKey)
            => ResourceGateway.UnloadTexture(textureKey);
    }
}