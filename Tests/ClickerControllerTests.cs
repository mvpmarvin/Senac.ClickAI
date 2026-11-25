using Senac.ClickAI;
using Xunit;

namespace Senac.ClickAI.Tests;

public sealed class ClickerControllerTests
{
    [Fact]
    public void StartsDisabled()
    {
        var action = new RecordingAction();
        var controller = new ClickerController(action);

        controller.ExecuteTick();

        Assert.False(controller.IsEnabled);
        Assert.Equal(0, action.CallCount);
    }

    [Fact]
    public void ExecutesOneActionPerTickWhenEnabled()
    {
        var action = new RecordingAction();
        var controller = new ClickerController(action);

        controller.Enable();
        controller.ExecuteTick();
        controller.ExecuteTick();

        Assert.Equal(2, action.CallCount);
    }

    [Fact]
    public void DisablePreventsFurtherActions()
    {
        var action = new RecordingAction();
        var controller = new ClickerController(action);

        controller.Enable();
        controller.Disable();
        controller.ExecuteTick();

        Assert.False(controller.IsEnabled);
        Assert.Equal(0, action.CallCount);
    }

    [Fact]
    public void UsesThreeSecondInterval()
    {
        Assert.Equal(3_000, ClickerController.IntervalMilliseconds);
    }

    private sealed class RecordingAction : IClickAction
    {
        public int CallCount { get; private set; }

        public void Execute() => CallCount++;
    }
}
