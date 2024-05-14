using Godot;
using System;
using System.Threading.Tasks;

public partial class Ball : RigidBody2D
{
    [ExportGroup("Child Nodes")]
    [Export]
    public Area2D AreaNode { get; private set; }
    public override void _Ready()
    {
        AreaNode.BodyEntered += HandlePlatformDisapearence;
    }

    private async void HandlePlatformDisapearence(Node body)
    {
        GD.Print("Called");
        if (body is Platform platform)
        {
            GD.Print("Before await");
            await ToSignal(GetTree().CreateTimer(1.0f), Timer.SignalName.Timeout);
            GD.Print("After await");

            platform.QueueFree();
        }
        GD.Print($"Body Name: {body.Name}");
    }

}
