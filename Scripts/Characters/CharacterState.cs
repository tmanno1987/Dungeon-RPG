using Godot;
using System;

public abstract partial class CharacterState : Node
{
    protected Character player;

    public override void _Ready()
    {
        player = GetOwner<Character>();
        
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        switch (what) {
            case GC.NOTIFY_ENTER_STATE:  // Enable Current State
                EnterState();
                SetPhysicsProcess(true);
                SetProcessInput(true);
                break;
            case GC.NOTIFY_EXIT_STATE:  // Disable Current State
                SetPhysicsProcess(false);
                SetProcessInput(false);
                ExitState();
                break;
            default:    // Ignore or Handle ANY Invalid Numbers Exceptions
                // Currently Ignoring
                break;
        }
    }

    protected virtual void EnterState() { }
    protected virtual void ExitState()  { }
}