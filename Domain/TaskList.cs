namespace Abobus.Domain;

public sealed class TaskList
{
    public List<Task> Tasks { get; init; }
    public int PercentCompleted => Tasks.Where(task => task.IsCompleted).Count() * 100 / Tasks.Count;

    public TaskList(List<Task> tasks)
    {
        Tasks = tasks;
    }
}
