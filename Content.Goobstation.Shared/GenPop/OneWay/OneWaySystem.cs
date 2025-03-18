using Robust.Shared.Physics.Events;

namespace Content.Goobstation.Shared.GenPop.OneWay;

public sealed class OneWaySystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<OneWayComponent, PreventCollideEvent>(OnPreventCollide);
    }

    private void OnPreventCollide(Entity<OneWayComponent> ent, ref PreventCollideEvent args)
    {
        var vel = args.OtherBody.LinearVelocity;
        var dir = Angle.FromWorldVec(vel).GetCardinalDir();

        var impacteePos = Angle.FromWorldVec(args.OurBody.LocalCenter);
        var impacterPos = Angle.FromWorldVec(args.OtherBody.LocalCenter);

        var approachDir = Angle.ShortestDistance(impacteePos, impacterPos).GetCardinalDir();

        Log.Info($"Velocity dir is {dir}, coming from {approachDir}.\nPassing if velocity dir is {ent.Comp.EntryDirection} or entry is NOT {ent.Comp.EntryDirection.GetOpposite()}");

        //
        if (dir != ent.Comp.EntryDirection || approachDir == ent.Comp.EntryDirection.GetOpposite())
        {
            args.Cancelled = true;
        }
    }
}
