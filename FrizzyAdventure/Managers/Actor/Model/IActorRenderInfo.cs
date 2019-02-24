namespace FrizzyAdventure.Managers.Actor.Model
{
    using Microsoft.Xna.Framework;
    using FrizzyAdventure.Managers.Resource.Model;

    internal interface IActorRenderInfo
    {
        Vector2 RenderVector { get; }

        Rectangle TextureClipping { get; }

        TextureKey TextureKey { get; }

        ActorZSort ZSort { get; }
    }
}