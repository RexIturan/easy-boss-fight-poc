using Godot;

public partial class PlayerHealthDisplay : HBoxContainer {
    [Export] private Health health;
    [Export] private Color fullColor = Color.FromHtml("#FFF");
    [Export] private Color emptyColor = Color.FromHtml("#AAA");
    [Export] private PackedScene liveDisplayPrefab;
    
    public override void _Ready() {
        base._Ready();

        health.Changed += OnHealthChanged;
        UpdateDisplay(health.Value, health.MaxValue);
    }

    private void OnHealthChanged(int newValue, int _oldValue) {
        UpdateDisplay(newValue, health.MaxValue);
    }

    private void UpdateDisplay(int value, int max) {
        foreach (var child in GetChildren()) {
            child.QueueFree();
        }

        for (int i = 0; i < max; i++) {
            var lifeItem = CreateLifeDisplay();
            if (i < value) {
                lifeItem.Color = fullColor;
            } else {
                lifeItem.Color = emptyColor;
            }
            AddChild(lifeItem);
        }
    }

    private ColorRect CreateLifeDisplay() {
        var colorRect = liveDisplayPrefab.Instantiate<ColorRect>();

        return colorRect;
    }
}