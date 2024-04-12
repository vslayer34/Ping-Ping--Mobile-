using Godot;

public partial class GameManager : Node2D
{
    [ExportGroup("Resource Refrences")]
    [Export]
    private RES_GameplayEvents _gameplayEvents;

    private Vector2 _viewPortSize;



    public override void _EnterTree()
    {
        base._EnterTree();

        // Get the view port size at the start of the game and save it
        _viewPortSize = GetViewportRect().Size;
        _gameplayEvents.ViewPortSize = _viewPortSize;
    }

    public override void _Ready()
    {
        
    }


    // Getters and Setters-------------------------------------------------------------------------

    /// <summary>
    /// Reference to the view port size
    /// </summary>
    public Vector2 ViewPortSize { get => _viewPortSize; }
}
