using Abobus.Domain;
using Xunit;
using FluentAssertions;

namespace Domain.Tests;

public class TaskTest
{
    [Fact]
    public void Description_GivenPuzzle_ReturnsItsDescription()
    {
        var puzzle = new Puzzle(1, "Puzzle desc", new ImageOffset(0, 0), "Good job");
        var task = new Task(puzzle);
        task.Description.Should().Be("Puzzle desc");
    }

    [Fact]
    public void Complete_MarksAsCompleted()
    {
        var puzzle = new Puzzle(1, "Puzzle desc", new ImageOffset(0, 0), "Good job");
        var task = new Task(puzzle);
        task.Complete();
        task.IsCompleted.Should().BeTrue();
    }
}
