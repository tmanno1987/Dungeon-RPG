using Godot;
using System;
using System.Linq;

public partial class EnemyChaseState : EnemyState
{
    [Export] private Timer chaseTimer;
    private CharacterBody3D target;

    protected override void EnterState()
    {
        player.AnimPlayer.Play(GC.ANIM_MOVE);
        target = player.ChaseAreaNode.GetOverlappingBodies().First() as CharacterBody3D;
        chaseTimer.Timeout += HandleTimeout;
        player.AttackAreaNode.BodyEntered += HandleAttackAreaBodyEntered;
        player.ChaseAreaNode.BodyExited += HandleChaseAreaBodyExit;
    }

    private void HandleChaseAreaBodyExit(Node3D body)
    {
        player.StateMachine.SwitchState<EnemyReturnState>();
    }

    private void HandleAttackAreaBodyEntered(Node3D body)
    {
        player.StateMachine.SwitchState<EnemyAttackState>();
    }

    private void HandleTimeout()
    {
        destination = target.GlobalPosition;
        player.AgentNode.TargetPosition = destination;
    }

    public override void _PhysicsProcess(double delta)
    {
        Move();
    }

    protected override void ExitState()
    {
        chaseTimer.Timeout -= HandleTimeout;
        player.AttackAreaNode.BodyEntered -= HandleAttackAreaBodyEntered;
        player.ChaseAreaNode.BodyExited -= HandleChaseAreaBodyExit;
    }
}
