using Godot;
using System;

public partial class EnemyReturnState : EnemyState
{
    public override void _Ready()
    {
        base._Ready();

        UpdateDestination(0);
    }

    protected override void EnterState()
    {
        player.AnimPlayer.Play(GC.ANIM_MOVE);

        player.AgentNode.TargetPosition = destination;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (player.AgentNode.IsNavigationFinished()) {
            player.StateMachine.SwitchState<EnemyPatrolState>();
        }

        Move();
    }
}
