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
    private float _horizontalSpeed = 10.0f;

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
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        if (@event is InputEventScreenTouch screenTouch)
        {
            if (!screenTouch.Pressed)
            {
                // GD.Print("Finger removed from screen");
                _isDragged = false;
                // GD.Print($"Is Dragged: {_isDragged}");
            }
        }

        if (@event is InputEventScreenDrag screenDrag)
        {
            if (_isDragged)
            {
                _touchPosition = screenDrag.Relative;
                // GD.Print($"Is Dragged: {_isDragged}");
                MoveHorizontally();
            }

            // else if (!screenDrag.IsCanceled())
            // {
            //     GD.Print("Platform is released");
            // }
        }
    }


    /// <summary>
    /// Handle the player touch input
    /// Indicata when the player is touching or releasing the platform
    /// </summary>
    private void HandlePlayerTouch(Node viewport, InputEvent @event, long shapeIdx)
    {
        if (@event is InputEventScreenTouch touch)
        {
            if (touch.Pressed)
            {
                GD.Print("Touched inside the sprite");
                _isDragged = true;
                // GD.Print($"Is Dragged: {_isDragged}");
                // _touchPosition = touch.Position;
            }
            // else
            // {
            //     GD.Print("Released");
            //     _isDragged = false;
            //     GD.Print($"Is Dragged: {_isDragged}");
            // }
        }
    }


    /// <summary>
    /// Move to the left continuasly
    /// </summary>
    /// <param name="delta"></param>
    private void MoveSideWays(float delta)
    {
        Translate(Vector2.Left * _horizontalSpeed * delta);
    }


    /// <summary>
    /// Move According to the finger relative position
    /// </summary>
    private void MoveHorizontally()
    {
        if (_touchPosition.Y > 0)
        {
            Translate
        }
        else if (_touchPosition.Y < 0)
        {

        }
    }
}
