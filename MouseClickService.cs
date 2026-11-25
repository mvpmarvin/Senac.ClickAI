using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Senac.ClickAI;

public sealed class MouseClickService : IClickAction
{
    private const uint InputMouse = 0;
    private const uint MouseEventLeftDown = 0x0002;
    private const uint MouseEventLeftUp = 0x0004;

    private readonly Func<Point> _targetPosition;

    public MouseClickService(Func<Point> targetPosition)
    {
        _targetPosition = targetPosition ?? throw new ArgumentNullException(nameof(targetPosition));
    }

    public void Execute()
    {
        Point target = _targetPosition();

        if (!SetCursorPos(target.X, target.Y))
        {
            throw new Win32Exception(Marshal.GetLastWin32Error(), "Não foi possível posicionar o ponteiro do mouse.");
        }

        MouseInput[] inputs =
        [
            new MouseInput { Type = InputMouse, Data = new NativeMouseInput { Flags = MouseEventLeftDown } },
            new MouseInput { Type = InputMouse, Data = new NativeMouseInput { Flags = MouseEventLeftUp } }
        ];

        uint sent = SendInput((uint)inputs.Length, inputs, Marshal.SizeOf<MouseInput>());
        if (sent != inputs.Length)
        {
            throw new Win32Exception(Marshal.GetLastWin32Error(), "Não foi possível simular o clique do mouse.");
        }
    }

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetCursorPos(int x, int y);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint SendInput(uint numberOfInputs, [In] MouseInput[] inputs, int inputSize);

    [StructLayout(LayoutKind.Sequential)]
    private struct MouseInput
    {
        public uint Type;
        public NativeMouseInput Data;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct NativeMouseInput
    {
        public int X;
        public int Y;
        public uint MouseData;
        public uint Flags;
        public uint Time;
        public IntPtr ExtraInfo;
    }
}
