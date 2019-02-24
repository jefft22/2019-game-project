namespace FrizzyAdventure.Managers.Actor
{
    using FrizzyAdventure.Managers.Actor.Model;
    using System.Collections.Generic;

    internal sealed class ActorManager
    {
        private readonly List<BaseActor> _actors = new List<BaseActor>();

        public ActorManager()
        {
        }

        public void AddActor(BaseActor actor)
        {
            _actors.Add(actor);
        }

        public IEnumerable<IActorPhysicalInfo> GetAllActorsPhysicalInfo()
            => _actors;

        public IEnumerable<IActorRenderInfo> GetAllActorsRenderInfo()
            => _actors;

        public void UpdateAllActors()
        {
            foreach (var actor in _actors)
            {
                actor.Update();
            }
        }
    }
}