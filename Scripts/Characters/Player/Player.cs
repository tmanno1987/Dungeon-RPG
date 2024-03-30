using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer animPlayer;
    [Export] private Sprite3D playerSprite;
    [Export] public StateMachine stateMachine;

    private Vector2 direction = new();

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new(direction.X, 0, direction.Y);
        Velocity *= 5;

        MoveAndSlide();
        Flip();
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(
            GC.INPUT_MOVE_LEFT,
            GC.INPUT_MOVE_RIGHT,
            GC.INPUT_MOVE_FORWARD,
            GC.INPUT_MOVE_BACKWARD
        );
    }

    private void Flip()
    {
        // Escape clause forces out of function if player is
        // moving along the Z-Axis or Idle.
        if (Velocity.X == 0) return;

        playerSprite.FlipH =  Velocity.X < 0;
    }

    public AnimationPlayer AnimPlayer {
        get => animPlayer;
    }

    public Vector2 Direction {
        get => direction;
    }
}
