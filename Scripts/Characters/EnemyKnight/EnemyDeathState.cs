using Godot;
using System;

public partial class EnemyDeathState : EnemyState
{
    protected override void EnterState()
    {
        player.AnimPlayer.Play(GC.ANIM_DEATH);
        player.AnimPlayer.AnimationFinished += HandleAnimFinished;
    }

    private void HandleAnimFinished(StringName animName)
    {
        player.PathNode.QueueFree();
    }
}