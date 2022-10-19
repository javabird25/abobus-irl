namespace Abobus.Domain;

public sealed class Task
{
    private readonly Puzzle _puzzle;
    private bool _isCompleted = false;

    public Task(Puzzle puzzle)
    {
        _puzzle = puzzle;
    }
}
