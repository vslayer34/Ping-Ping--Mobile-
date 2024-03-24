using Godot;

public partial class StartPlatform : AnimatableBody2D
{
    [ExportGroup("Required Nodes")]
    [Export]
    private CollisionShape2D _collisionShape;
    private int _collisionShapeIndex;
    [ExportGroup("")]

    private bool _isDragged;

    [ExportCategory("Platform properties")]
    [Export]
    private float _speed = 10.0f;

    private Vector2 _touchPosition;


    //---------------------------------------------------------------------------------------------

    public override void _Ready()
    {
        base._Ready();
        InputEvent += HandlePlayerTouch;
        _collisionShapeIndex = _collisionShape.GetIndex();
    }

    public override void _PhysicsProcess(double delta)
    {
        MoveSideWays((float) delta);
        GD.Print(_touchPosition);
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        if (_isDragged && @event is InputEventScreenDrag screenDrag)
        {
            _touchPosition = screenDrag.Relative;
        }
    }

    private void HandlePlayerTouch(Node viewport, InputEvent @event, long shapeIdx)
    {
        if (@event is InputEventScreenTouch touch)
        {
            if (touch.Pressed)
            {
                GD.Print("Touched inside the sprite");
                _isDragged = true;
                _touchPosition = touch.Position;
            }
            else
            {
                GD.Print("Touched outside");
                _isDragged = false;
            }
        }
    }

    private void MoveSideWays(float delta)
    {
        Translate(Vector2.Left * _speed * delta);
    }


    private void MoveHorizontally()
    {

    }
}
