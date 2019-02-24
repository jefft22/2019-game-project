namespace FrizzyAdventure.Managers.Actor.Player.Model
{
    internal enum ActionState
    {
        NoAction,

        // Push/pull actions
        Pushing,
        Pulling,
        GrippingObject,

        // Sword actions
        SwingSword,
        HoldSword,
        SpinSword
    }
}