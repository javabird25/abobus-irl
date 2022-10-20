namespace Abobus.Domain.Tests;

using System.Collections.Generic;

public sealed class TaskListTest
{
    [Fact]
    public void Tasks_GivenTaskList_ReturnsItsTasks()
    {
        var task = new Task(new Puzzle(1, "Puzzle desc", new ImageOffset(0, 0), "Good job"));
        var taskList = new TaskList(new List<Task> { task });
        taskList.Tasks[0].Should().Be(task);
    }

    [Fact]
    public void PercentCompleted()
    {
        var task1 = new Task(new Puzzle(1, "Puzzle desc", new ImageOffset(0, 0), "Good job"));
        var task2 = new Task(new Puzzle(2, "Puzzle desc", new ImageOffset(0, 0), "Good job"));
        var task3 = new Task(new Puzzle(3, "Puzzle desc", new ImageOffset(0, 0), "Good job"));
        var taskList = new TaskList(new List<Task> { task1, task2, task3 });

        taskList.PercentCompleted.Should().Be(0);
        task1.Complete();
        taskList.PercentCompleted.Should().Be(33);
        task2.Complete();
        taskList.PercentCompleted.Should().Be(66);
        task3.Complete();
        taskList.PercentCompleted.Should().Be(100);
    }
}
