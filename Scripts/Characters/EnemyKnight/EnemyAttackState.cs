using Godot;
using System;

public partial class EnemyAttackState : EnemyState
{
    protected override void EnterState()
    {
        player.AnimPlayer.Play(GC.ANIM_ATTACK);
    }

    protected override void ExitState()
    {
        base.ExitState();
    }
}
