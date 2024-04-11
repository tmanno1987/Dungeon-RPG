using Godot;
using System;

public abstract partial class PlayerState : CharacterState
{
    public override void _Ready()
    {
        base._Ready();

        player.GetStatResource(Stat.Health).OnZero += HandleZeroHealth;
    }

    protected void CheckForAttackInput()
    {
        if (Input.IsActionJustPressed(GC.INPUT_ATTACK)) {
            player.StateMachine.SwitchState<PlayerAttackState>();
        }
    }

    private void HandleZeroHealth()
    {
        player.StateMachine.SwitchState<PlayerDeathState>();
    }
}