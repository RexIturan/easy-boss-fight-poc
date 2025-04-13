using Godot;

public partial class HitBox : Area2D {
    [Export] private int damage = 0;
    [Export] private Faction faction;
    
    public override void _Ready() {
        base._Ready();

        AreaEntered += OnAreaEntered;
    }

    private void OnAreaEntered(Area2D area) {
        if (area is Hurtbox hurtbox) {
            if (hurtbox.Faction is { } && hurtbox.Faction.Value == faction.Value) {
                return;
            }
            
            hurtbox.Hit(damage);
        }
    }
}