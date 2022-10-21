namespace Abobus.Domain;

public sealed class GamePassword
{
    public static GamePassword Generate()
    {
        var n = (int)Random.Shared.NextInt64(100_000, 999_999);
        return new GamePassword(n);
    }

    private bool Equals(GamePassword other)
    {
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is GamePassword other && Equals(other);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    public static bool operator ==(GamePassword? left, GamePassword? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(GamePassword? left, GamePassword? right)
    {
        return !Equals(left, right);
    }

    private readonly int _value;

    public GamePassword(int value)
    {
        _value = value;
    }

    public override string ToString() => _value.ToString();
}
