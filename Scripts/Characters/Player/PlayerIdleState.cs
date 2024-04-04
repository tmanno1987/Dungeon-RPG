using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{
    public override void _PhysicsProcess(double delta)
    {
        if (player.Direction != Vector2.Zero) {
            player.StateMachine.SwitchState<PlayerMoveState>();
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GC.INPUT_DASH)) {
            player.StateMachine.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        player.AnimPlayer.Play(GC.ANIM_IDLE);
    }
}
