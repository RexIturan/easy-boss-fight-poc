using Godot;

namespace easybossfightpoc.code.combat;

public partial class Projectile : Node2D {
    [Export] public Vector2 Direction = Vector2.Up;
    [Export] public float Speed = 1;
    [Export] public float Lifetime = 1;

    public override void _Ready() {
        base._Ready();

        GetTree().CreateTimer(Lifetime).Timeout += OnTimeout;
    }

    public override void _PhysicsProcess(double delta) {
        base._PhysicsProcess(delta);

        Position += Direction.Normalized() * (Speed * (float) delta);
    }
    
    private void OnTimeout() {
        GetParent().RemoveChild(this);
        QueueFree();
    }
}