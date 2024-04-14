using System;
using Godot;

public partial class ReactToBall : Area2D
{
    public override void _Ready()
    {
        BodyEntered += HandlePlatformDisapearence;
    }

    private void HandlePlatformDisapearence(Node2D body)
    {
        GD.Print("Ball hit the platform");
    }

}
