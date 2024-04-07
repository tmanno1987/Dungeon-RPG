using Godot;
using System;

public abstract partial class PlayerState : CharacterState
{
    protected void CheckForAttackInput()
    {
        if (Input.IsActionJustPressed(GC.INPUT_ATTACK)) {
            player.StateMachine.SwitchState<PlayerAttackState>();
        }
    }
}