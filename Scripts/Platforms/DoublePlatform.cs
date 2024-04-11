using Godot;
using System;

public partial class DoublePlatform : Platform
{
    public override void _Ready()
    {
        base._Ready();

        _platformHeight = GetPlatformHeight();

        GD.Print(_gameplayEvents.ViewPortSize);
    }
}
