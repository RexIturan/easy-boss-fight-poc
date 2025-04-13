using Godot;

public partial class Rotator : Polygon2D {
    [Export] private float rotationSpeed = 15;
    
    public override void _Process(double delta) {
        base._Process(delta);
        
        Rotation = (Rotation + Mathf.DegToRad(rotationSpeed) * (float) delta) % Mathf.Tau;
    }
}