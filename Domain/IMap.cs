namespace Abobus.Domain;

public interface IMap
{
    int Id { get; init; }
    string Name { get; init; }
    string SchemeImageUrl { get; init; }
    List<Puzzle> PuzzlePool { get; init; }
}