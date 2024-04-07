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
        player.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;
    }

    protected override void ExitState()
    {
        player.ChaseAreaNode.BodyEntered -= HandleChaseAreaBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (player.AgentNode.IsNavigationFinished()) {
            player.StateMachine.SwitchState<EnemyPatrolState>();
        }

        Move();
    }
}
