using Godot;
using System;

public partial class EnemyIdleState : EnemyState
{
    protected override void EnterState()
    {
        player.AnimPlayer.Play(GC.ANIM_IDLE);
    }

    public override void _PhysicsProcess(double delta)
    {
        player.StateMachine.SwitchState<EnemyReturnState>();
    }
}
