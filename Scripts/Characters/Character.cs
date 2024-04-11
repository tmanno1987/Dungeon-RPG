using Godot;
using System;
using System.Linq;

public abstract partial class Character : CharacterBody3D
{
    [Export] private StatResource[] stats;

    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimPlayer { get; private set; }
    [Export] public StateMachine StateMachine { get; private set; }
    [Export] public Sprite3D PlayerSprite { get; private set; }
    [Export] public CollisionShape3D HitboxShape { get; private set; }
    [Export] public Area3D HurtBox { get; private set; }
    [Export] public Area3D HitBox { get; private set; }
    

    [ExportGroup("AI Nodes")]
    [Export] public NavigationAgent3D AgentNode { get; private set; }
    [Export] public Area3D AttackAreaNode { get; private set; }
    [Export] public Area3D ChaseAreaNode { get; private set; }
    [Export] public Path3D PathNode { get; private set; }    

    protected Vector2 direction = new();

    public override void _Ready()
    {
        HurtBox.AreaEntered += HandleHurtBoxEnter;
    }

    private void HandleHurtBoxEnter(Area3D area)
    {
        StatResource health = GetStatResource(Stat.Health);
        Character attacker = area.GetOwner<Character>();
        health.StatValue -= attacker.GetStatResource(Stat.Strength).StatValue;
        GD.Print(health.StatValue);
    }

    public StatResource GetStatResource(Stat stat)
    {
        return stats.Where((element) => element.StatType == stat).FirstOrDefault();
    }

    public void ToggleHitbox(bool flag)
    {
        HitboxShape.Disabled = flag;
    }

    public void Flip()
    {
        // Escape clause forces out of function if player is
        // moving along the Z-Axis or Idle.
        if (Velocity.X == 0) return;

        PlayerSprite.FlipH =  Velocity.X < 0;
    }

    /*
     * Private Access Getter/Setter
     */
    public Vector2 Direction {
        get => direction;
    }
}
