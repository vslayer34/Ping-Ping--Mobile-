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
    private GameManager _gameManager;


    [ExportGroup("")]

    [ExportCategory("Timer wait times")]
    [Export]
    private float _minWaitTime;

    [Export]
    private float _maxWaitTime;



    //---------------------------------------------------------------------------------------------

    private DoublePlatform _newlyCreatedPlatform;


    public override void _Ready()
    {
        _timer.Timeout += SpawnNewPlatform;
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
}