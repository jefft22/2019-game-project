namespace FrizzyAdventure.Managers.Actor.Block
{
    using FrizzyAdventure.Managers.Actor.Model;
    using FrizzyAdventure.Exceptions;
    using FrizzyAdventure.Managers.Resource.Model;

    internal sealed class BlockActor : BaseActor
    {
        public BlockActor()
        {
            Clipping = true;
            X1 = 64;
            Y1 = 64;
            X2 = 80;
            Y2 = 80;

            _renderVector.X = 64;
            _renderVector.Y = 64;
            _textureClipping.X = _textureClipping.Y = 0;
            _textureClipping.Height = _textureClipping.Width = 16;
            TextureKey = TextureKey.Dungeon;
            ZSort = ActorZSort.AlwaysOnBottom;
        }

        public BlockActor(BasicActorConstruction actorConstruction)
        {
            switch (actorConstruction.ActorConstructionType)
            {
                case BasicActorConstructionType.DungeonBlock_01:
                    Clipping = true;

                    X1 = actorConstruction.X;
                    X2 = actorConstruction.X + 16;
                    Y1 = actorConstruction.Y;
                    Y2 = actorConstruction.Y + 16;

                    _renderVector.X = actorConstruction.X;
                    _renderVector.Y = actorConstruction.Y;
                    _textureClipping.X = _textureClipping.Y = 0;
                    _textureClipping.Height = _textureClipping.Width = 16;

                    TextureKey = TextureKey.Dungeon;
                    ZSort = ActorZSort.AlwaysOnBottom;

                    break;

                case BasicActorConstructionType.DungeonBlock_03:
                    Clipping = false;

                    X1 = actorConstruction.X;
                    X2 = actorConstruction.X + 16;
                    Y1 = actorConstruction.Y;
                    Y2 = actorConstruction.Y + 16;

                    _renderVector.X = actorConstruction.X;
                    _renderVector.Y = actorConstruction.Y;
                    _textureClipping.X = 16;
                    _textureClipping.Y = 0;
                    _textureClipping.Height = 16;
                    _textureClipping.Width = 16;

                    TextureKey = TextureKey.Dungeon;
                    ZSort = ActorZSort.AlwaysOnBottom;

                    break;

                default:
                    throw new ActorConstructionTypeNotImplementedException("BlockActor does not implement: " + actorConstruction.ActorConstructionType.ToString());
            }
        }

        protected override void HandleEventActionCore(IActorPhysicalInfo sendingActorPhysicalInfo, ActorEvent actorEvent)
        {
        }

        protected override void UpdateCore()
        {
        }
    }
}