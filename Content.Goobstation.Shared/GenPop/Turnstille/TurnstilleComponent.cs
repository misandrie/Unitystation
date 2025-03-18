using Robust.Shared.GameStates;
using Robust.Shared.Serialization;

namespace Content.Goobstation.Shared.GenPop.Turnstille;

[RegisterComponent, NetworkedComponent]
public sealed partial class TurnstilleComponent : Component
{
    /// <summary>
    /// Start countdown on ID when going through it?
    /// Otherwise, act as an "Exit" turnstile and let people out when they did their time.
    /// </summary>
    [DataField]
    public bool Entry;

    /// <summary>
    /// Can be pried open by a crowbar when losing power.
    /// </summary>
    [DataField]
    public bool Pryable = true;
}

[Serializable,NetSerializable]
public enum TurnstileVisuals : byte
{
    State,
}

[Serializable, NetSerializable]
public enum TurnstileVisualState : byte
{
    Base,
    Allow,
    Deny,
}
