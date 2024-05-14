using System;
using Godot;

public abstract partial class Platform : AnimatableBody2D
{
    [ExportGroup("Required Nodes")]
    [Export]
    protected RES_GameplayEvents _gameplayEvents;

    [Export]
    protected CollisionShape2D _collisionShape;

    [Export]
    protected CompressedTexture2D _platformSprite;


    [Export]
    protected GameManager _gameManager;
    
    protected int _collisionShapeIndex;
    [ExportGroup("")]

    //---------------------------------------------------------------------------------------------

    protected bool _isDragged;
    protected int _currentDragIndex;

    [ExportCategory("Platform properties")]
    [Export]
    protected float _horizontalSpeed = 50.0f;
    
    [Export]
    protected float _verticalSpeed = 150.0f;

    [Export]
    public bool IsChildPlatform { get; set; }

    protected float _platformHeight;
    [ExportCategory("")]

    protected Vector2 _touchPosition;

    //---------------------------------------------------------------------------------------------    

    public override void _Ready()
    {
        base._Ready();
        InputEvent += HandlePlayerTouch;

        // if (GetOwner<GameManager>() is GameManager)
        // {
        //     _gameManager = GetOwner<GameManager>();   
        // }
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!IsChildPlatform)
        {
            MoveSideWays((float) delta);
            if (_isDragged)
            {
                MoveHorizontally((float) delta);
            }
        }
    }


    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        if (@event is InputEventScreenTouch screenTouch)
        {
            if (_currentDragIndex == screenTouch.Index && !screenTouch.Pressed)
            {
                _isDragged = false;
            }
        }

        if (@event is InputEventScreenDrag screenDrag)
        {
            if (_isDragged && _currentDragIndex == screenDrag.Index)
            {
                _touchPosition = screenDrag.Relative;
            }
        }
    }


    /// <summary>
    /// Move to the left continuasly
    /// </summary>
    /// <param name="delta"></param>
    protected void MoveSideWays(float delta)
    {
        Translate(Vector2.Left * _horizontalSpeed * delta);
    }


    /// <summary>
    /// Move According to the finger relative position
    /// </summary>
    protected void MoveHorizontally(float delta)
    {
        if (_touchPosition.Y <= 0 && GlobalPosition.Y >= (0.0f + _platformHeight / 2))
        {
            GlobalPosition += new Vector2((Vector2.Left * _horizontalSpeed * delta).X, (Vector2.Up * _verticalSpeed * delta).Y);
        }
        else if (_touchPosition.Y >= 0 && GlobalPosition.Y <= (_gameplayEvents.ViewPortSize.Y - _platformHeight / 2))
        {
            GlobalPosition += new Vector2((Vector2.Left * _horizontalSpeed * delta).X, (Vector2.Down * _verticalSpeed * delta).Y);
        }
    }


    /// <summary>
    /// Get the platform collider height
    /// </summary>
    /// <returns>The height of the platform</returns>
    protected float GetPlatformHeight()
    {
        RectangleShape2D shape = _collisionShape.Shape as RectangleShape2D;
        return shape.Size.Y;
    }

    /// <summary>
    /// Handle the player touch input
    /// Indicata when the player is touching or releasing the platform
    /// </summary>
    protected void HandlePlayerTouch(Node viewport, InputEvent @event, long shapeIdx)
    {
        if (@event is InputEventScreenTouch touch)
        {
            if (touch.Pressed)
            {
                // GD.Print("Touched inside the sprite");
                _isDragged = true;
                _currentDragIndex = touch.Index;
            }
        }
    }
}