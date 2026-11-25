#nullable enable

namespace Senac.ClickAI;

partial class ClickAI
{
    private System.ComponentModel.IContainer? components = null;
    private Button closeButton = null!;
    private Button toggleButton = null!;
    private Panel controlsPanel = null!;
    private System.Windows.Forms.Timer clickTimer = null!;
    private System.Windows.Forms.Timer flashTimer = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        closeButton = new Button();
        toggleButton = new Button();
        controlsPanel = new Panel();
        clickTimer = new System.Windows.Forms.Timer(components);
        flashTimer = new System.Windows.Forms.Timer(components);
        controlsPanel.SuspendLayout();
        SuspendLayout();
        closeButton.AccessibleName = "Fechar ClickAI";
        closeButton.AccessibleRole = AccessibleRole.PushButton;
        closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        closeButton.BackColor = Color.FromArgb(32, 32, 32);
        closeButton.FlatAppearance.BorderColor = Color.White;
        closeButton.FlatAppearance.BorderSize = 2;
        closeButton.FlatStyle = FlatStyle.Flat;
        closeButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        closeButton.ForeColor = Color.White;
        closeButton.Location = new Point(370, 12);
        closeButton.Name = "closeButton";
        closeButton.Size = new Size(38, 38);
        closeButton.TabIndex = 0;
        closeButton.Text = "×";
        closeButton.UseVisualStyleBackColor = false;
        closeButton.Click += CloseButton_Click;
        toggleButton.AccessibleName = "Ativar ou desativar cliques";
        toggleButton.AccessibleRole = AccessibleRole.CheckButton;
        toggleButton.AutoSize = true;
        toggleButton.BackColor = Color.FromArgb(32, 32, 32);
        toggleButton.FlatAppearance.BorderColor = Color.White;
        toggleButton.FlatAppearance.BorderSize = 2;
        toggleButton.FlatStyle = FlatStyle.Flat;
        toggleButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        toggleButton.ForeColor = Color.White;
        toggleButton.Location = new Point(130, 12);
        toggleButton.MinimumSize = new Size(160, 42);
        toggleButton.Name = "toggleButton";
        toggleButton.Padding = new Padding(12, 0, 12, 0);
        toggleButton.Size = new Size(160, 42);
        toggleButton.TabIndex = 1;
        toggleButton.Text = "LIGAR (ENTER/ESPAÇO)";
        toggleButton.UseVisualStyleBackColor = false;
        toggleButton.Click += ToggleButton_Click;
        controlsPanel.BackColor = Color.FromArgb(16, 16, 16);
        controlsPanel.Controls.Add(toggleButton);
        controlsPanel.Controls.Add(closeButton);
        controlsPanel.Dock = DockStyle.Bottom;
        controlsPanel.Location = new Point(0, 360);
        controlsPanel.Name = "controlsPanel";
        controlsPanel.Size = new Size(420, 60);
        controlsPanel.TabIndex = 0;
        clickTimer.Interval = ClickerController.IntervalMilliseconds;
        clickTimer.Tick += ClickTimer_Tick;
        flashTimer.Interval = 180;
        flashTimer.Tick += FlashTimer_Tick;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(32, 32, 32);
        ClientSize = new Size(420, 420);
        Controls.Add(controlsPanel);
        DoubleBuffered = true;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = true;
        MinimumSize = new Size(300, 300);
        Name = "ClickAI";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "ClickAI - Clique automático";
        controlsPanel.ResumeLayout(false);
        controlsPanel.PerformLayout();
        ResumeLayout(false);
    }
}