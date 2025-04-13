using Godot;

public partial class PlayerBody : Polygon2D {
    [Export] private Health health;
    [Export] private AnimationPlayer animationPlayer;

    public override void _Ready() {
        base._Ready();

        health.Changed += OnHealthChanged;
    }

    private void OnHealthChanged(int newvalue, int oldvalue) {
        if (newvalue < oldvalue) {
            PlayHurtAnimation();
        }
    }

    private void PlayHurtAnimation() {
        animationPlayer.ResetSection();
        animationPlayer.Play("hurt_anim");
    }
}