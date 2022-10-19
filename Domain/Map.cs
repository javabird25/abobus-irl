namespace Abobus.Domain;

public sealed class Map
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string SchemeImageUrl { get; init; }
    public List<Puzzle> PuzzlePool { get; init; }

    public Map(int id, string name, string schemeImageUrl, List<Puzzle> puzzlePool)
    {
        Id = id;
        Name = name;
        SchemeImageUrl = schemeImageUrl;
        PuzzlePool = puzzlePool;
    }
}
