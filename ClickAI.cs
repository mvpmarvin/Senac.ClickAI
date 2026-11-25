namespace Senac.ClickAI;

public partial class ClickAI : Form
{
    private static readonly Color TransparencyColor = Color.Magenta;
    private static readonly Color CrosshairColor = Color.White;
    private static readonly Color ActiveColor = Color.FromArgb(0, 150, 70);
    private readonly ClickerController _controller;
    private bool _isFlashing;

    public ClickAI()
    {
        InitializeComponent();
        TransparencyKey = TransparencyColor;
        _controller = new ClickerController(new MouseClickService(GetTargetScreenPosition));
        AccessibleName = "ClickAI, clique automático";
        AccessibleDescription = "Clique esquerdo periódico no centro da janela.";
        UpdateToggleAppearance();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Rectangle target = GetTargetRectangle();
        using Brush targetBrush = new SolidBrush(TransparencyColor);
        e.Graphics.FillRectangle(targetBrush, target);

        int centerX = target.Left + target.Width / 2;
        int centerY = target.Top + target.Height / 2;
        Color color = _isFlashing ? Color.Red : CrosshairColor;
        using Pen activePen = new(color, 4F);
        e.Graphics.DrawLine(activePen, target.Left, centerY, target.Right, centerY);
        e.Graphics.DrawLine(activePen, centerX, target.Top, centerX, target.Bottom);
    }

    private Rectangle GetTargetRectangle()
    {
        const int targetSize = 150;
        int centerX = ClientSize.Width / 2;
        int centerY = (ClientSize.Height - controlsPanel.Height) / 2;
        return new Rectangle(centerX - targetSize / 2, centerY - targetSize / 2, targetSize, targetSize);
    }

    private Point GetTargetScreenPosition()
    {
        Rectangle target = GetTargetRectangle();
        return PointToScreen(new Point(target.Left + target.Width / 2, target.Top + target.Height / 2));
    }

    private void ToggleButton_Click(object? sender, EventArgs e)
    {
        _controller.Toggle();
        clickTimer.Enabled = _controller.IsEnabled;
        UpdateToggleAppearance();
    }

    private void ClickTimer_Tick(object? sender, EventArgs e)
    {
        try
        {
            _controller.ExecuteTick();
            _isFlashing = true;
            flashTimer.Start();
            Invalidate();
        }
        catch (Exception exception)
        {
            StopAfterFailure(exception);
        }
    }

    private void FlashTimer_Tick(object? sender, EventArgs e)
    {
        _isFlashing = false;
        flashTimer.Stop();
        Invalidate();
    }

    private void StopAfterFailure(Exception exception)
    {
        _controller.Disable();
        clickTimer.Stop();
        UpdateToggleAppearance();
        MessageBox.Show(this, $"O ClickAI foi interrompido devido a uma falha:\n{exception.Message}",
            "Falha no ClickAI", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void UpdateToggleAppearance()
    {
        toggleButton.BackColor = _controller.IsEnabled ? ActiveColor : Color.FromArgb(32, 32, 32);
        toggleButton.Text = _controller.IsEnabled ? "LIGADO" : "LIGAR (ENTER/ESPAÇO)";
        toggleButton.AccessibleDescription = _controller.IsEnabled
            ? "Cliques ativos. Pressione ENTER ou ESPAÇO para desligar."
            : "Cliques inativos. Pressione ENTER ou ESPAÇO para ligar.";
    }

    private void CloseButton_Click(object? sender, EventArgs e) => Close();
}