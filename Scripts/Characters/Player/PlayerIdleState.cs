using Godot;
using System;

public partial class PlayerIdleState : Node
{
    private Player player;

    public override void _Ready()
    {
        player = GetOwner<Player>();
    }

    public override void _PhysicsProcess(double delta)
    {
        // Escape if Direction is NOT equal to (0, 0)
        if (player.Direction != Vector2.Zero) {
            player.stateMachine.SwitchState<PlayerMoveState>();
        }
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            player.AnimPlayer.Play(GC.ANIM_IDLE);
        }
    }
}
