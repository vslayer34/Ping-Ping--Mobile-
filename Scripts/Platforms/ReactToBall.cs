using System;
using System.Threading.Tasks;
using Godot;

public partial class ReactToBall : Area2D
{
    public override void _Ready()
    {
        BodyEntered += HandlePlatformDisapearence;
    }



    /// <summary>
    /// Remove the platform once it refelected the ball
    /// </summary>
    private async void HandlePlatformDisapearence(Node2D body)
    {
        // await Task.Delay(1000);
        // GetOwner<AnimatableBody2D>().QueueFree();
    }

}
