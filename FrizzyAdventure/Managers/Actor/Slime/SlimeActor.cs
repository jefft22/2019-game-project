namespace FrizzyAdventure.Managers.Actor.Slime
{
    using FrizzyAdventure.Exceptions;
    using FrizzyAdventure.Managers.Actor;
    using FrizzyAdventure.Managers.Actor.Model;
    using FrizzyAdventure.Managers.Actor.Player;
    using FrizzyAdventure.Managers.Actor.Slime.Model;
    using FrizzyAdventure.Managers.Resource.Model;

    internal sealed class SlimeActor : BaseActor
    {
        private ActionState _actionState = ActionState.SquishInPlace;

        private readonly ActorManager _actorManager;

        private int _aiSwitchTimer = 0;

        private int _animationTimer = 0;

        public SlimeActor(ActorManager actorManager, BasicActorConstruction basicActorConstruction)
        {
            _actorManager = actorManager;

            switch (basicActorConstruction.ActorConstructionType)
            {
                case BasicActorConstructionType.SlimeActive:
                    _actionState = ActionState.SquishInPlace;
                    _aiSwitchTimer = 120;
                        
                    Clipping = false;

                    _renderVector.X = basicActorConstruction.X;
                    _renderVector.Y = basicActorConstruction.Y;

                    _textureClipping.X = 16;
                    _textureClipping.Y = 0;
                    _textureClipping.Width = 16;
                    _textureClipping.Height = 16;

                    TextureKey = TextureKey.Slime;

                    X1 = basicActorConstruction.X + 4;
                    X2 = basicActorConstruction.X + 12;
                    Y1 = basicActorConstruction.Y + 8;
                    Y2 = basicActorConstruction.Y + 16;
                    break;

                default:
                    throw new ActorConstructionTypeNotImplementedException("Slime actor does not implement " + basicActorConstruction.ActorConstructionType.ToString());
            }
        }

        protected override void HandleEventActionCore(IActorPhysicalInfo sendingActorPhysicalInfo, ActorEvent actorEvent)
        {
        }

        protected override void UpdateCore()
        {
            switch (_actionState)
            {
                case ActionState.SquishInPlace:
                    UpdateSquishInPlace();
                    break;

                case ActionState.SquishWhileMoving:
                    UpdateSquishWhileMoving();
                    break;
            }

            // Update render position
            _renderVector.X = X1;
            _renderVector.Y = Y1;
        }

        private void UpdateSquishInPlace()
        {
            // Update AI
            _aiSwitchTimer--;

            if (_aiSwitchTimer <= 0)
            {
                _actionState = ActionState.SquishWhileMoving;
                _aiSwitchTimer = 100;
                _animationTimer = 0;

                // Get player position
                var actors = _actorManager.GetAllActorsPhysicalInfo();
                DX = 0f;
                DY = 0f;

                foreach (var actor in actors)
                {
                    if (actor is PlayerActor)
                    {
                        if (actor.X2 <= (X1 - 8))
                        {
                            DX = -0.3f;
                        }
                        else if (actor.X1 >= (X2 + 8))
                        {
                            DX = 0.3f;
                        }

                        if (actor.Y2 <= (Y1 - 8))
                        {
                            DY = -0.3f;
                        }
                        else if (actor.Y1 >= (Y2 + 8))
                        {
                            DY = 0.3f;
                        }

                        break;
                    }
                }

                // No match?
                if (DX == 0f && DY == 0f)
                {
                    _actionState = ActionState.SquishInPlace;
                    _aiSwitchTimer = 30;
                }
            }

            // Update animation
            _animationTimer++;

            if (_animationTimer >= 24)
            {
                _animationTimer = 0;
            }

            if (_animationTimer < 12)
            {
                _textureClipping.X = 16;
                _textureClipping.Y = 0;
            }
            else if (_animationTimer < 24)
            {
                _textureClipping.X = 32;
                _textureClipping.Y = 0;
            }
        }

        private void UpdateSquishWhileMoving()
        {
            // Update AI
            _aiSwitchTimer--;

            if (_aiSwitchTimer <= 0)
            {
                _actionState = ActionState.SquishInPlace;
                _aiSwitchTimer = 60;
                _animationTimer = 0;
                DX = 0;
                DY = 0;
            }

            X1 += DX;
            X2 += DX;
            Y1 += DY;
            Y2 += DY;

            // Update movement
            _renderVector.X = X1;
            _renderVector.Y = Y1;

            // Update animation
            _animationTimer++;

            if (_animationTimer >= 16)
            {
                _animationTimer = 0;
            }

            if (_animationTimer < 8)
            {
                _textureClipping.X = 16;
                _textureClipping.Y = 0;
            }
            else
            {
                _textureClipping.X = 32;
                _textureClipping.Y = 0;
            }
        }
    }
}
