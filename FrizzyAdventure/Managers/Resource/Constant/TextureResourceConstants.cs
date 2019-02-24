namespace FrizzyAdventure.Managers.Resource.Constant
{
    using FrizzyAdventure.Managers.Resource.Model;
    using System.Collections.Generic;

    internal static class TextureResourceConstants
    {
        public static Dictionary<TextureKey, string> TextureLookupTable = new Dictionary<TextureKey, string>
        {
            { TextureKey.NullTexture, "" },

            { TextureKey.Dungeon, "textures/dungeon" },

            { TextureKey.Frizzy, "textures/frizzy" },

            { TextureKey.Forest, "textures/forest" },

            { TextureKey.GameplayHud, "textures/gameplayhud" },

            { TextureKey.Slime, "textures/slime" }
        };
    }
}