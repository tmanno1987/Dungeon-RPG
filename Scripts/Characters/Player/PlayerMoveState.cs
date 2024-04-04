using Godot;
using System;

public partial class PlayerMoveState : PlayerState
{
    [Export(PropertyHint.Range, "0, 20, 0.1")] private float speed = 5;
    public override void _PhysicsProcess(double delta)
    {
        if (player.Direction == Vector2.Zero) {
            player.StateMachine.SwitchState<PlayerIdleState>();
            return;
        }

        player.Velocity = new(player.Direction.X, 0, player.Direction.Y);
        player.Velocity *= speed;

        player.MoveAndSlide();
        player.Flip();
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GC.INPUT_DASH)) {
            player.StateMachine.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        player.AnimPlayer.Play(GC.ANIM_MOVE);
    }
}
