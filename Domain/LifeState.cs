namespace Abobus.Domain;

using Ardalis.SmartEnum;

public abstract class LifeState : SmartEnum<LifeState>
{
    public static readonly LifeState Alive = new AliveType();
    public static readonly LifeState KilledInThisRound = new KilledInThisRoundType();
    public static readonly LifeState KilledInPreviousRound = new KilledInPreviousRoundType();
    public static readonly LifeState Kicked = new KickedType();

    private LifeState(string name, int value) : base(name, value)
    {
    }

    public abstract bool IsAlive { get; }

    private sealed class AliveType : LifeState
    {
        public AliveType() : base("Alive", 1)
        {
        }

        public override bool IsAlive => true;
    }

    private sealed class KilledInThisRoundType : LifeState
    {
        public KilledInThisRoundType() : base("KilledInThisRound", 2)
        {
        }

        public override bool IsAlive => false;
    }

    private sealed class KilledInPreviousRoundType : LifeState
    {
        public KilledInPreviousRoundType() : base("KilledInPreviousRound", 3)
        {
        }

        public override bool IsAlive => false;
    }

    private sealed class KickedType : LifeState
    {
        public KickedType() : base("Kicked", 4)
        {
        }

        public override bool IsAlive => false;
    }
}
