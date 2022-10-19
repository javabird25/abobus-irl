namespace Abobus.Domain;

public sealed class Puzzle
{
    public int Id { get; init; }
    public string Description { get; init; }
    public ImageOffset ImageOffset { get; init; }
    public string CompletionPassword { get; init; }

    public Puzzle(int id, string description, ImageOffset imageOffset, string completionPassword)
    {
        Id = id;
        Description = description;
        ImageOffset = imageOffset;
        CompletionPassword = completionPassword;
    }
}
