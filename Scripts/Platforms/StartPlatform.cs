using Godot;

public partial class StartPlatform : Platform
{
    [ExportGroup("Required Nodes")]
    [Export]
    protected ColorRect _testColorRect;

    [ExportGroup("")]

    [ExportCategory("Platform properties")]

    [Export]
    protected Color _rectColor;

    public override void _Ready()
    {
        base._Ready();
        // Get a reference to the game manager at the start of the game

        // InputEvent += HandlePlayerTouch;

        _testColorRect.Size = (_collisionShape.Shape as RectangleShape2D).Size;
        _testColorRect.Color = _rectColor;

        _platformHeight = GetPlatformHeight();
    }
}
