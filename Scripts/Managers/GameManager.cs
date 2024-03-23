using Godot;
using System;

public partial class GameManager : Node2D
{
    private Vector2 _viewPortSize;


    public override void _Ready()
    {
        // Get the view port size at the start of the game
        _viewPortSize = GetViewportRect().Size;
    }


    // Getters and Setters-------------------------------------------------------------------------

    /// <summary>
    /// Reference to the view port size
    /// </summary>
    public Vector2 ViewPortSize { get => _viewPortSize; }
}
