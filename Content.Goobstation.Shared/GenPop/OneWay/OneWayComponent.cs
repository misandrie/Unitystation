using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.GenPop.OneWay;

/// <summary>
///  Defines that this entity can only be passed one-way.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
[Access(typeof(OneWaySystem))]
public sealed partial class OneWayComponent : Component
{
    /// <summary>
    /// The direction this entity is barred from passing through.
    /// Note that this only uses cardinal directions.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite), AutoNetworkedField]
    public Direction EntryDirection;
}
