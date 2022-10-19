namespace Abobus.Domain;

public sealed class Crewmate : Player
{
    public TaskList Tasks { get; init; }
    public LifeState LifeState { get; init; }

    public Crewmate(int id, string name, TaskList tasks) : base(id, name)
    {
        Tasks = tasks;
        LifeState = LifeState.Alive;
    }
}
