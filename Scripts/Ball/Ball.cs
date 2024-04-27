using Godot;
using System;
using System.Threading.Tasks;

public partial class Ball : RigidBody2D
{
    public override void _Ready()
    {
        BodyEntered += HandlePlatformDisapearence;
    }

    private void HandlePlatformDisapearence(Node body)
    {
        // if (body is AnimatableBody2D platform)
        // {
        //     await Task.Delay(1000);
        //     platform.QueueFree();
        // }
        GD.Print(body.Name);
    }

}
