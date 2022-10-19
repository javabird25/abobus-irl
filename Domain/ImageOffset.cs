namespace Abobus.Domain;

public sealed class ImageOffset
{
    public int X { get; init; }
    public int Y { get; init; }

    public ImageOffset(int x, int y)
    {
        X = x;
        Y = y;
    }
}
