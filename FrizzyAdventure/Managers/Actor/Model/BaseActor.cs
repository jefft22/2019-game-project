namespace FrizzyAdventure.Managers.Actor.Model
{
    using Microsoft.Xna.Framework;
    using FrizzyAdventure.Managers.Resource.Model;

    internal abstract class BaseActor : IActorPhysicalInfo, IActorRenderInfo
    {
        public bool Clipping { get; protected set; } = false;

        public float DX { get; protected set; } = 0.0f;

        public float DY { get; protected set; } = 0.0f;

        public float X1 { get; protected set; } = 0.0f;

        public float X2 { get; protected set; } = 0.0f;

        public float Y1 { get; protected set; } = 0.0f;

        public float Y2 { get; protected set; } = 0.0f;

        public Vector2 RenderVector { get { return _renderVector; } }

        public Rectangle TextureClipping { get { return _textureClipping; } }

        public TextureKey TextureKey { get; protected set; } = TextureKey.NullTexture;

        public ActorZSort ZSort { get; set; } = ActorZSort.YSorted;

        protected DirectionState _directionState = DirectionState.Down;

        protected Vector2 _renderVector;

        protected Rectangle _textureClipping;

        protected BaseActor()
        {
            _renderVector.X = _renderVector.Y = 0.0f;
            _textureClipping.X = _textureClipping.Y = 0;
            _textureClipping.Width = _textureClipping.Height = 0;
        }

        public void HandleEventAction(IActorPhysicalInfo sendingActorPhysicalInfo, ActorEvent actorEvent)
            => HandleEventActionCore(sendingActorPhysicalInfo, actorEvent);

        public void Update()
            => UpdateCore();

        protected int GetDirectionAsInteger(DirectionState directionState)
        {
            if (directionState == DirectionState.Right)
            {
                return 0;
            }
            else if (directionState == DirectionState.Left)
            {
                return 1;
            }
            else if (directionState == DirectionState.Up)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        protected bool IsActorCollidingWithBothXAndYDeltaMovement(IActorPhysicalInfo actorPhysicalInfo)
        {
            if ((X1 + DX) < actorPhysicalInfo.X2 &&
                (X2 + DX) > actorPhysicalInfo.X1 &&
                (Y1 + DY) < actorPhysicalInfo.Y2 &&
                (Y2 + DY) > actorPhysicalInfo.Y1)
            {
                return true;
            }

            return false;
        }

        protected bool IsActorCollidingWithXDeltaMovement(IActorPhysicalInfo actorPhysicalInfo)
        {
            if ((X1 + DX) < actorPhysicalInfo.X2 &&
                (X2 + DX) > actorPhysicalInfo.X1 &&
                Y1 < actorPhysicalInfo.Y2 &&
                Y2 > actorPhysicalInfo.Y1)
            {
                return true;
            }

            return false;
        }

        protected bool IsActorCollidingWithYDeltaMovement(IActorPhysicalInfo actorPhysicalInfo)
        {
            if (X1 < actorPhysicalInfo.X2 &&
                X2 > actorPhysicalInfo.X1 &&
                (Y1 + DY) < actorPhysicalInfo.Y2 &&
                (Y2 + DY) > actorPhysicalInfo.Y1)
            {
                return true;
            }

            return false;
        }

        protected bool IsActorCollidingWithoutDeltaMovement(IActorPhysicalInfo actorPhysicalInfo)
        {
            if (X1 < actorPhysicalInfo.X2 &&
                X2 > actorPhysicalInfo.X1 &&
                Y1 < actorPhysicalInfo.Y2 &&
                Y2 > actorPhysicalInfo.Y1)
            {
                return true;
            }

            return false;
        }

        protected bool IsActorToTheBottom(IActorPhysicalInfo actorPhysicalInfo)
            => (Y2 <= actorPhysicalInfo.Y1) ? true : false;

        protected bool IsActorToTheLeft(IActorPhysicalInfo actorPhysicalInfo)
            => (X1 >= actorPhysicalInfo.X2) ? true : false;

        protected bool IsActorToTheRight(IActorPhysicalInfo actorPhysicalInfo)
            => (X2 <= actorPhysicalInfo.X1) ? true : false;

        protected bool IsActorToTheTop(IActorPhysicalInfo actorPhysicalInfo)
            => (Y1 >= actorPhysicalInfo.Y2) ? true : false;

        protected abstract void HandleEventActionCore(IActorPhysicalInfo sendingActorPhysicalInfo, ActorEvent actorEvent);

        protected abstract void UpdateCore();
    }
}