using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer dashTimer;

    [Export(PropertyHint.Range, "0, 20, 0.1")]
    private float speed = 10;

    public override void _Ready()
    {
        base._Ready();

        dashTimer.Timeout += HandleDashTimeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        player.MoveAndSlide();
        player.Flip();
    }

    protected override void EnterState()
    {
        player.AnimPlayer.Play(GC.ANIM_DASH);
        player.Velocity = new(player.Direction.X, 0, player.Direction.Y);
        
        if (player.Velocity == Vector3.Zero) {
            player.Velocity = player.PlayerSprite.FlipH ? Vector3.Left : Vector3.Right;
        }

        player.Velocity *= speed;
        dashTimer.Start();
    }

    private void HandleDashTimeout()
    {
        player.StateMachine.SwitchState<PlayerIdleState>();
        player.Velocity = Vector3.Zero;
    }
}
