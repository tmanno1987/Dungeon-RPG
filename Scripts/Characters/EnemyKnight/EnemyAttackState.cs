using Godot;
using System;
using System.Linq;

public partial class EnemyAttackState : EnemyState
{
    private Vector3 targetPos;
    protected override void EnterState()
    {
        player.AnimPlayer.Play(GC.ANIM_ATTACK);
        Node3D target = player.AttackAreaNode.GetOverlappingBodies().First();
        targetPos = target.GlobalPosition;
        player.AnimPlayer.AnimationFinished += HandleAnimFinished;
    }

    protected override void ExitState()
    {
        player.AnimPlayer.AnimationFinished -= HandleAnimFinished;
    }

    private void PerformHit()
    {
        player.ToggleHitbox(false);
        player.HitBox.GlobalPosition = targetPos;
    }

    private void HandleAnimFinished(StringName animName)
    {
        player.ToggleHitbox(true);
        Node3D target = player.AttackAreaNode.GetOverlappingBodies().FirstOrDefault();

        if (target == null) {
            Node3D chaseTarget = player.ChaseAreaNode.GetOverlappingBodies().FirstOrDefault();

            if (chaseTarget == null) {
                player.StateMachine.SwitchState<EnemyReturnState>();
                return;
            }

            player.StateMachine.SwitchState<EnemyChaseState>();
            return;
        }
        player.AnimPlayer.Play(GC.ANIM_ATTACK);
        targetPos = target.GlobalPosition;

        Vector3 direction = player.GlobalPosition.DirectionTo(targetPos);
        player.PlayerSprite.FlipH = direction.X < 0;
    }
}
