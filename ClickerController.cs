namespace Senac.ClickAI;

public interface IClickAction
{
    void Execute();
}

public sealed class ClickerController
{
    public const int IntervalMilliseconds = 3_000;

    private readonly IClickAction _clickAction;

    public ClickerController(IClickAction clickAction)
    {
        _clickAction = clickAction ?? throw new ArgumentNullException(nameof(clickAction));
    }

    public bool IsEnabled { get; private set; }

    public void Enable() => IsEnabled = true;

    public void Disable() => IsEnabled = false;

    public void Toggle()
    {
        IsEnabled = !IsEnabled;
    }

    public void ExecuteTick()
    {
        if (IsEnabled)
        {
            _clickAction.Execute();
        }
    }
}
