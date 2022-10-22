namespace Abobus.Domain;

public interface IMap
{
    string Name { get; init; }
    string SchemeImageUrl { get; init; }
    List<Puzzle> PuzzlePool { get; init; }
}