using Godot;
using System;

public partial class PlatformDestroyer : Area2D
{
    private GameManager _gameManager;

    public override void _Ready()
    {
        _gameManager = GetOwner<GameManager>();
        GD.Print(_gameManager.ViewPortSize);
    }
}
