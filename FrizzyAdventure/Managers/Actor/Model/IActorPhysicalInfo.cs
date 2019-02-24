namespace FrizzyAdventure.Managers.Actor.Model
{
    internal interface IActorPhysicalInfo
    {
        // Clipping (true = other actors cannot walk through)
        bool Clipping { get; }

        // Delta (movement)
        float DX { get; }
        float DY { get; }

        // X Y cordinates for clipping box
        float X1 { get; }
        float X2 { get; }

        float Y1 { get; }
        float Y2 { get; }

        void HandleEventAction(IActorPhysicalInfo sendingActorPhysicalInfo, ActorEvent actorEvent);
    }
}