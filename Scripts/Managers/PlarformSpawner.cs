using System;
using Godot;

public partial class PlarformSpawner : Node2D
{
    [ExportGroup("Required Nodes")]
    [Export]
    private Timer _timer;

    [Export]
    private PackedScene _newPlatform;

    [Export]
    private PackedScene _newStartPlatform;

    [Export]
    private Marker2D _startPlatformSpawnPoint;

    [Export]
    private GameManager _gameManager;


    [ExportGroup("")]

    [ExportCategory("Timer wait times")]
    [Export]
    private float _minWaitTime;

    [Export]
    private float _maxWaitTime;


    //---------------------------------------------------------------------------------------------

    private Vector2 _viewportSize;



    //---------------------------------------------------------------------------------------------

    private DoublePlatform _newlyCreatedPlatform;


    public override void _Ready()
    {
        _timer.Timeout += SpawnNewPlatform;
        _viewportSize = GetViewportRect().Size;

        SpawnStartPlatform();
    }


    /// <summary>
    /// Spawn new platform when the timer run out
    /// </summary>
    private void SpawnNewPlatform()
    {
        _timer.WaitTime = GD.RandRange(_minWaitTime, _maxWaitTime);
        
        _newlyCreatedPlatform = _newPlatform.Instantiate() as DoublePlatform;
        
        _newlyCreatedPlatform.GlobalPosition = Position;
        _gameManager.AddChild(_newlyCreatedPlatform);

        GD.Print("newly created platform position" + _newlyCreatedPlatform.Position);
        GD.Print("Spawner position: " + Position);
        GD.Print("");
    }



    /// <summary>
    /// Spawn a new start platform to the scene
    /// </summary>
    private void SpawnStartPlatform()
    {
        _startPlatformSpawnPoint.GlobalPosition = _viewportSize / 2.0f;

        StartPlatform startPlatform = _newStartPlatform.Instantiate<StartPlatform>();
        _startPlatformSpawnPoint.AddChild(startPlatform);

        startPlatform.Position = _startPlatformSpawnPoint.GlobalPosition;
        GD.Print($"Start platform spawn position: {startPlatform.GlobalPosition}");
    }
}