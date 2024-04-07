using Godot;
using System;

public partial class PlayerAttackState : PlayerState
{
    [Export] private Timer comboTimer;
    private int comboCounter = 1;
    private int maxComboCount = 3; // set to attack anim count + 1

    public override void _Ready()
    {
        base._Ready();

        comboTimer.Timeout += () => comboCounter = 1;
    }

    protected override void EnterState()
    {
        player.AnimPlayer.Play(GC.ANIM_ATTACK + comboCounter, -1, 1.5f);

        player.AnimPlayer.AnimationFinished += HandleAnimFinished;
    }

    private void HandleAnimFinished(StringName animName)
    {
        comboCounter++;
        comboCounter = Mathf.Wrap(comboCounter, 1, maxComboCount);

        player.StateMachine.SwitchState<PlayerIdleState>();
    }

    protected override void ExitState()
    {
        player.AnimPlayer.AnimationFinished -= HandleAnimFinished;
        comboTimer.Start();
    }
}
