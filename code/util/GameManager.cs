using Godot;

public partial class GameManager : Node {
    [Export] private Health playerHealth;
    [Export] private Health bossHealth;
    [Export] private CanvasLayer winScreen;
    [Export] private Button retryButton;
    
    public override void _Ready() {
        base._Ready();

        winScreen.Visible = false;
        retryButton.Pressed += ResetLevel;
        
        playerHealth.Death += HandleDeath;
        bossHealth.Death += HandleWin;
    }

    private void HandleWin() {
        GetTree().Paused = true;
        winScreen.Visible = true;
    }

    private void HandleDeath() {
        Callable.From(ResetLevel).CallDeferred();
    }

    public void ResetLevel() {
        GetTree().Paused = false;
        GetTree().ReloadCurrentScene();
    }
}