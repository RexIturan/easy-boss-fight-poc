using Godot;

public enum Factions {
    None,
    Player,
    Enemy
}

public partial class Faction : Node {
    [Export] public Factions Value;
}