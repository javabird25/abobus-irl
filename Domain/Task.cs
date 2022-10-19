namespace Abobus.Domain;

public sealed class Task
{
    public string Description => _puzzle.Description;
    public bool IsCompleted => _isCompleted;
    private readonly Puzzle _puzzle;
    private bool _isCompleted = false;

    public void Complete()
    {
        _isCompleted = true;
    }

    public Task(Puzzle puzzle)
    {
        _puzzle = puzzle;
    }
}
