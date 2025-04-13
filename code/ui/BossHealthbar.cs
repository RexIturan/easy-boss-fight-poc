using Godot;

public partial class BossHealthbar : ProgressBar {
    [Export] private Health health;
    
    public override void _Ready() {
        base._Ready();

        health.Changed += OnHealthChanged;
        UpdateDisplay(health.Value, health.MaxValue);
    }

    private void OnHealthChanged(int newValue, int _oldValue) {
        UpdateDisplay(newValue, health.MaxValue);
    }

    private void UpdateDisplay(int value, int max) {
        SetMax(max);
        SetValue(value);
    }
}