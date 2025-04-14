using easybossfightpoc.code.combat;
using Godot;

namespace easybossfightpoc.code.boss.pattern;

public partial class ShootSpikes : Node2D {
    [Export] private Node2D playerNode;
    [Export] private Node2D origin;
    [Export] private PackedScene projectilePrefab;

    [Export] public bool Active { get; set; }
    [Export] public float cooldown = 1;
    private bool cooldownDone = true;

    [Export] private int shots = 1;
    private int currentShots = 0;
    [Export] public float sleep = 1;
    private bool sleepDone = true;

    public override void _Process(double delta) {
        base._Process(delta);

        if (Active && cooldownDone && sleepDone) {
            var dirToPlayer =  playerNode.GlobalPosition - origin.GlobalPosition;
            var projectile = CreateProjectile();
            projectile.Direction = dirToPlayer;
            AddChild(projectile);
            projectile.Position = origin.GlobalPosition;
            cooldownDone = false;
            GetTree().CreateTimer(cooldown).Timeout += () => cooldownDone = true;
            currentShots++;
            
            if (currentShots >= shots) {
                sleepDone = false;
                GetTree().CreateTimer(sleep).Timeout += () => {
                    sleepDone = true;
                    currentShots = 0;
                };
            }
        }
    }

    private Projectile CreateProjectile() {
        return projectilePrefab.Instantiate<Projectile>();
    }
}