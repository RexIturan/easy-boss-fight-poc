using Godot;

public partial class GameManager : Node {
    [Export] private Health playerHealth;

    public override void _Ready() {
        base._Ready();

        playerHealth.Death += HandleDeath;
    }

    private void HandleDeath() {
        Callable.From(ResetLevel).CallDeferred();
    }

    public void ResetLevel() {
        GetTree().ReloadCurrentScene();
    }
}