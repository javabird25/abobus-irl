namespace Abobus.Domain;

public sealed class Map : IMap
{
    public string Name { get; init; }
    public string SchemeImageUrl { get; init; }
    public List<Puzzle> PuzzlePool { get; init; }

    public Map(string name, string schemeImageUrl, List<Puzzle> puzzlePool)
    {
        Name = name;
        SchemeImageUrl = schemeImageUrl;
        PuzzlePool = puzzlePool;
    }
}
