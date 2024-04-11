using Godot;
using System;

public partial class PlayerDeathState : PlayerState
{
    protected override void EnterState()
    {
        player.AnimPlayer.Play(GC.ANIM_DEATH);
        player.AnimPlayer.AnimationFinished += HandleAnimFinished;
    }

    private void HandleAnimFinished(StringName animName)
    {
        GameEvents.RaiseEndGame();

        player.QueueFree();
    }
}
