namespace FrizzyAdventure.Managers.Actor.Player
{
    using FrizzyAdventure.Managers.Actor;
    using FrizzyAdventure.Managers.Actor.Model;
    using FrizzyAdventure.Managers.Actor.Player.Model;
    using FrizzyAdventure.Managers.Controller;

    internal sealed class PlayerActor : BaseActor
    {
        private const int PlayerHeight = 10;
        private const int PlayerWidth = 10;

        private ActionState _actionState = ActionState.NoAction;

        private readonly ActorManager _actorManager;

        private int _animationTimer = 0;

        private readonly ControllerManager _controllerManager;

        private MovementState _movementState = MovementState.NoMovement;

        public PlayerActor(ActorManager actorManager, ControllerManager controllerManager) : base()
        {
            _actorManager = actorManager;
            _controllerManager = controllerManager;

            Clipping = false;
            X1 = 100.0f;
            Y1 = 100.0f;
            X2 = 116.0f;
            Y2 = 116.0f;

            _renderVector.X = 100.0f;
            _renderVector.Y = 100.0f;
            _textureClipping.X = 0;
            _textureClipping.Y = 16;
            _textureClipping.Width = PlayerWidth;
            _textureClipping.Height = PlayerHeight;
            TextureKey = Resource.Model.TextureKey.Frizzy;
        }

        protected override void HandleEventActionCore(IActorPhysicalInfo sendingActorPhysicalInfo, ActorEvent actorEvent)
        {
        }

        protected override void UpdateCore()
        {
            var controllerState = _controllerManager.GetControllerState();

            if (controllerState.DownButtonIsPressed)
            {
                _directionState = DirectionState.Down;
                _movementState = MovementState.Walking;
                DY = 1.0f;
            }
            else if (controllerState.UpButtonIsPressed)
            {
                _directionState = DirectionState.Up;
                _movementState = MovementState.Walking;
                DY = -1.0f;
            }

            if (controllerState.LeftButtonIsPressed)
            {
                _directionState = DirectionState.Left;
                _movementState = MovementState.Walking;
                DX = -1.0f;
            }
            else if (controllerState.RightButtonIsPressed)
            {
                _directionState = DirectionState.Right;
                _movementState = MovementState.Walking;
                DX = 1.0f;
            }

            if (!controllerState.DownButtonIsPressed && !controllerState.UpButtonIsPressed)
            {
                DY = 0.0f;
            }

            if (!controllerState.LeftButtonIsPressed && !controllerState.RightButtonIsPressed)
            {
                DX = 0.0f;
            }

            if (!controllerState.DownButtonIsPressed && !controllerState.UpButtonIsPressed &&
                !controllerState.LeftButtonIsPressed && !controllerState.RightButtonIsPressed)
            {
                _movementState = MovementState.Standing;
            }

            // Slow movement when diagonally walking
            if ((DX > 0.1 || DX < -0.1) && (DY > 0.1 || DY < -0.1))
            {
                DX *= 0.75f;
                DY *= 0.75f;
            }

            UpdateMovement();
            UpdateAnimation();

            // Update rendering information
            _renderVector.X = X1 - 3;
            _renderVector.Y = Y1 - 6;
        }

        private void UpdateAnimation()
        {
            if (_movementState == MovementState.Standing)
            {
                _animationTimer = 0;
                _textureClipping.X = 0;
                _textureClipping.Y = 0 + (16 * GetDirectionAsInteger(_directionState));
                _textureClipping.Height = 16;
                _textureClipping.Width = 16;
            }

            if (_movementState == MovementState.Walking)
            {
                _animationTimer++;
                _textureClipping.Y = 0 + (16 * GetDirectionAsInteger(_directionState));
                _textureClipping.Height = 16;
                _textureClipping.Width = 16;

                if (_animationTimer < 8)
                {
                    _textureClipping.X = 16;

                }
                else if (_animationTimer < 13)
                {
                    _textureClipping.X = 0;
                }
                else
                {
                    _animationTimer = 0;
                }
            }
        }

        private void UpdateMovement()
        {
            var actors = _actorManager.GetAllActorsPhysicalInfo();

            foreach (var actor in actors)
            {
                // Do not compare player or no clipping actors
                if (actor is PlayerActor || !actor.Clipping)
                {
                    continue;
                }

                // X movement clipping
                if (!IsActorCollidingWithoutDeltaMovement(actor) && IsActorCollidingWithXDeltaMovement(actor))
                {
                    DX = 0.0f;
                    
                    if (IsActorToTheLeft(actor))
                    {
                        X1 = actor.X2 + 0.1f;
                    }
                    else if (IsActorToTheRight(actor))
                    {
                        X1 = actor.X1 - PlayerWidth - 0.1f;
                    }
                }

                // Y movement clipping
                if (!IsActorCollidingWithoutDeltaMovement(actor) && IsActorCollidingWithYDeltaMovement(actor))
                {
                    DY = 0.0f;

                    if (IsActorToTheBottom(actor))
                    {
                        Y1 = actor.Y1 - PlayerHeight - 0.1f;
                    }
                    else if (IsActorToTheTop(actor))
                    {
                        Y1 = actor.Y2 + 0.1f;
                    }
                }

                // Checking for corner-collision where both X and Y together would allow you to clip inside an actor
                if (!IsActorCollidingWithoutDeltaMovement(actor) && IsActorCollidingWithBothXAndYDeltaMovement(actor))
                {
                    if (IsActorToTheTop(actor))
                    {
                        DY = 0;
                    }

                    if (IsActorToTheRight(actor))
                    {
                        DX = 0;
                    }
                }
            }

            X1 += DX;
            Y1 += DY;
            X2 = X1 + PlayerWidth;
            Y2 = Y1 + PlayerHeight;
        }
    }
}