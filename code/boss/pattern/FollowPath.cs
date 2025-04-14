using Godot;

public partial class FollowPath : Node2D {
    [Export] private PathFollow2D pathFollow2D;
    [Export] private Node2D parent;
    [Export] private float speed = 1;

    public override void _Ready() {
        base._Ready();

        pathFollow2D.Loop = true;
    }

    public override void _Process(double delta) {
        base._Process(delta);

        pathFollow2D.ProgressRatio += (speed * (float) delta) % 1;
    }

    public override void _PhysicsProcess(double delta) {
        base._PhysicsProcess(delta);

        parent.Position = pathFollow2D.GlobalPosition;
    }
}