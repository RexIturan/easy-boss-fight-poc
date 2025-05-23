using Godot;

public partial class Health : Node {
    [Signal] public delegate void ChangedEventHandler(int newValue, int oldValue);
    [Signal] public delegate void DeathEventHandler();
    
    [Export] public int MaxValue;
    
    private int health = 0;
    [Export] public int Value {
        get => health;
        set {
            if (health != value) {
                var old = health;
                health = value;
                // GD.Print($"health changed was {old}, now {health}");
                EmitSignal(SignalName.Changed, health, old);

                if (health <= 0) {
                    EmitSignal(SignalName.Death);
                }
            }
        }
    }
    
    public override void _EnterTree() {
        base._EnterTree();

        Value = MaxValue;
    }
}