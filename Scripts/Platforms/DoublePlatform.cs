using Godot;
using System;

public partial class DoublePlatform : Platform
{
    [Export]
    // public Platform LeftPlatform { get; private set; }
    public AnimatableBody2D LeftPlatform { get; private set; }

    [Export]
    // public Platform RightPlatform { get; private set; }
    public AnimatableBody2D RightPlatform { get; private set; }


    // public override void _Ready()
    // {
    //     base._Ready();

    //     // _platformHeight = GetPlatformHeight();
    //     // LeftPlatform.IsChildPlatform = true;
    //     // RightPlatform.IsChildPlatform = true;
    // }

    // public override void _PhysicsProcess(double delta)
    // {
    //     base._PhysicsProcess(delta);
    //     // MoveHorizontally((float)delta);

    //     // KeepPlatformsTogether();
    // }


    private void KeepPlatformsTogether()
    {
        // GD.Print($"Left platform position: {LeftPlatform.Position}");
        // GD.Print($"Right platform position: {RightPlatform.Position}");
        // GD.Print();

        if (LeftPlatform == null || RightPlatform == null)
        {
            return;
        }

        if (LeftPlatform.Position.Y != RightPlatform.Position.Y)
        {
            RightPlatform.Position = new Vector2(Position.X + RightPlatform.Position.X, LeftPlatform.Position.Y);
            // RightPlatform.GlobalPosition = Vector2.Zero;

            GD.Print($"Left platform position: {LeftPlatform.Position}");
            GD.Print($"Right platform position: {RightPlatform.Position}");
            GD.Print();

            // LeftPlatform.Position = new Vector2(LeftPlatform.Position.X, RightPlatform.Position.Y);
            // LeftPlatform.Translate(new Vector2(LeftPlatform.Position.X, RightPlatform.Position.Y));
            // GD.Print($"Right Platform Position: {RightPlatform.Position}");
        }
        // else if (RightPlatform.Position.Y != LeftPlatform.Position.Y)
        // {
        //     LeftPlatform.Position = new Vector2(LeftPlatform.Position.X, RightPlatform.Position.Y);
        //     // RightPlatform.Position = new Vector2(RightPlatform.Position.X, LeftPlatform.Position.Y);
        // }
    }
}
