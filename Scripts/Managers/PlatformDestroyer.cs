using Godot;
using System;

public partial class PlatformDestroyer : Area2D
{
    private GameManager _gameManager;
    private CollisionShape2D _collider;

    public override void _Ready()
    {
        _gameManager = GetOwner<GameManager>();
        _collider = GetNode<CollisionShape2D>("CollisionShape2D");
        BodyEntered += FreePlatform;

        SetUpColliderPosition();
        
    }


    /// <summary>
    /// Set the position of the collider outside of the viewport to the left
    /// </summary>
    private void SetUpColliderPosition()
    {
        SetUpRectangleSize();
        _collider.Position = new Vector2(-50.0f, _gameManager.ViewPortSize.Y / 2);
    }


    /// <summary>
    /// Set the rectancle size of the collider
    /// </summary>
    private void SetUpRectangleSize()
    {
        float rectancleWidth = 50.0f;
        var rectancleShape = _collider.Shape as RectangleShape2D;
        rectancleShape.Size = new Vector2(rectancleWidth, _gameManager.ViewPortSize.Y);
    }


    /// <summary>
    /// Destroy the platform after leaving the screen
    /// </summary>
    /// <param name="body">The platform</param>
    private void FreePlatform(Node2D body)
    {
        if (body is not Platform)
        {
            return;
        }

        body.QueueFree();
    }
}
