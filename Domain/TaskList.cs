namespace Abobus.Domain;

public sealed class TaskList
{
    public List<Task> Tasks { get; init; }

    public TaskList(List<Task> tasks)
    {
        Tasks = tasks;
    }
}
