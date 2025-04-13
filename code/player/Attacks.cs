using Godot;

public partial class Attacks : Node2D {
    [Export] private AnimationPlayer animationPlayer;

    public override void _Process(double delta) {
        base._Process(delta);

        if (Input.IsActionJustPressed("attack_base")) {
            Strike();
        }
    }

    public void Strike() {
        animationPlayer.ResetSection();
        animationPlayer.Play("strike");
    }
}