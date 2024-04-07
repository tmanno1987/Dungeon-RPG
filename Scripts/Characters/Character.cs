using Godot;
using System;

public abstract partial class Character : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimPlayer { get; private set; }
    [Export] public Sprite3D PlayerSprite { get; private set; }
    [Export] public StateMachine StateMachine { get; private set; }

    [ExportGroup("AI Nodes")]
    [Export] public Path3D PathNode { get; private set; }
    [Export] public NavigationAgent3D AgentNode { get; private set; }
    [Export] public Area3D ChaseAreaNode { get; private set; }
    [Export] public Area3D AttackAreaNode { get; private set; }

    protected Vector2 direction = new();

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
