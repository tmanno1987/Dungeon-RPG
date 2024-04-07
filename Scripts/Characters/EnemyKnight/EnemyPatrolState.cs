using Godot;
using System;

public partial class EnemyPatrolState : EnemyState
{
    [ExportGroup("Timer")]
    [Export] private Timer idleTimer;
    [Export(PropertyHint.Range, "0, 10, 0.2")] private float maxIdleTime = 1;
    private int pointIndex = 0;

    protected override void EnterState()
    {
        player.AnimPlayer.Play(GC.ANIM_MOVE);

        pointIndex = 1;
        UpdateDestination(pointIndex);
        player.AgentNode.TargetPosition = destination;

        player.AgentNode.NavigationFinished += HandleNavigationFinished;
        idleTimer.Timeout += HandleTimeout;
        player.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;
    }

    private void HandleTimeout()
    {
        player.AnimPlayer.Play(GC.ANIM_MOVE);
        UpdateDestination(Mathf.Wrap(++pointIndex, 0, player.PathNode.Curve.PointCount));
        player.AgentNode.TargetPosition = destination;
    }

    private void HandleNavigationFinished()
    {
        player.AnimPlayer.Play(GC.ANIM_IDLE);
        
        RandomNumberGenerator rng = new();
        idleTimer.WaitTime = rng.RandfRange(0, maxIdleTime);

        idleTimer.Start();
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!idleTimer.IsStopped()) return;

        Move();
    }

    protected override void ExitState()
    {
        player.AgentNode.NavigationFinished -= HandleNavigationFinished;
        idleTimer.Timeout -= HandleTimeout;
        player.ChaseAreaNode.BodyEntered -= HandleChaseAreaBodyEntered;
    }
}
