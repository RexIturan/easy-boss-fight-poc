using Godot;

public partial class MoveOnPath : PathFollow2D {
    [Export] private float speed = 1;

    public override void _Process(double delta) {
        base._Process(delta);

        Progress += speed * (float) delta;
    }
}