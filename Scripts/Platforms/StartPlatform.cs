using Godot;

public partial class StartPlatform : AnimatableBody2D
{
    [ExportGroup("Required Nodes")]
    [Export]
    private CollisionShape2D _collisionShape;
    private int _collisionShapeIndex;

    private bool _isDragged;


    //---------------------------------------------------------------------------------------------

    public override void _Ready()
    {
        base._Ready();
        InputEvent += HandlePlayerTouch;
        _collisionShapeIndex = _collisionShape.GetIndex();
    }

    private void HandlePlayerTouch(Node viewport, InputEvent @event, long shapeIdx)
    {
        if (@event is InputEventScreenTouch touch)
        {
            if (touch.Pressed)
            {
                GD.Print("Touched inside the sprite");
            }
            else
            {
                GD.Print("Touched outside");
            }
        }
    }


    // public override void _Input(InputEvent @event)
    // {
    //     base._Input(@event);
    //     if (@event is InputEventScreenTouch touch)
    //     {
    //         if (touch.Pressed)
    //         {
    //             GD.Print("touch happened");
    //         }
    //     }
    // }
}
