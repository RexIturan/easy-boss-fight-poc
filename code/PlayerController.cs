using Godot;

public partial class PlayerController : CharacterBody2D {
    [Export] private float speed = 10;
    [Export] private float gravityMultiplier = 1;
    [Export] private float gravity = 20.0f;
    [Export] private float dampedGravity = 10.0f;
    [Export] private float jumpAcceleration = 100.0f;

    private Vector2 Acceleration = Vector2.Zero;
    private float input = 0;
    private bool jumping = false;
    private bool jumpImpulse = false;

    public override void _Process(double delta) {
        base._Process(delta);

        input = Input.GetAxis("move_left", "move_right");

        jumping = Input.IsActionPressed("jump");

        if (Input.IsActionJustPressed("jump")) {
            jumpImpulse = true;
        }

        // input = inputSpeed;
        GD.Print($"{input}");
    }

    public override void _PhysicsProcess(double delta) {
        // Acceleration = Vector2.Zero;

        if (!IsOnFloor()) {
            jumpImpulse = false;
            
            if (jumping) {
                Acceleration.Y = dampedGravity * gravityMultiplier;
            } else {
                Acceleration.Y = gravity * gravityMultiplier;
            }
        }

        if (IsOnFloor() && jumpImpulse) {
            Acceleration.Y = -jumpAcceleration;
            jumpImpulse = false;
        }

        var velocity = Velocity;

        velocity += Acceleration * (float) delta;

        velocity.X = input * speed;

        GD.Print($"{velocity}");

        Velocity = velocity;

        // var motion = velocity * (float) delta;
        MoveAndSlide();
    }
}