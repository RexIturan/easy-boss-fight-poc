using Godot;

public partial class BossController : AnimatableBody2D {
    [Export] private Health health;
    [Export] private Node2D pattern;
    [Export] private CpuParticles2D particles2D;

    public override void _Ready() {
        base._Ready();

        health.Death += OnDeath;
    }

    private void OnDeath() {
        particles2D.SetEmitting(true);
        pattern.SetProcess(false);
    }
}