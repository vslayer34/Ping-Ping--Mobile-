using Godot;
using System;
using System.Reflection;

public partial class StartPlatform : AnimatableBody2D
{
    private bool _isDragged;


    //---------------------------------------------------------------------------------------------

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        if (@event is InputEventScreenTouch touch)
        {
            if (touch.Pressed)
            {
                GD.Print("touch happened");
            }
        }
    }
}
