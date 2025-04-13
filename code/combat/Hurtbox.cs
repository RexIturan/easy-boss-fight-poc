using Godot;

public partial class Hurtbox : Area2D {
    [Export] private Health health;
    [Export] public Faction Faction;

    public void Hit(int damage) {
        health.Value -= damage;
    }
}