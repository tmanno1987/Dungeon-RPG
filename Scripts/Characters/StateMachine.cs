using Godot;
using System;
using System.Linq;

public partial class StateMachine : Node
{
    [ExportGroup("State Machine")]
    [Export] private Node currentState;
    [Export] private Node[] states;
    //private Player player;

    public override void _Ready()
    {
        currentState.Notification(GC.NOTIFY_ENTER_STATE);
    }

    public void SwitchState<T>() 
    {
        Node newState = states.Where((state) => state is T).FirstOrDefault();
        /* Following Note displays what above code is performing behind the scenes.
        Node newState = null;

        foreach (Node state in states) {
            if (state is T) {
                newState = state;
            }
        } */
        
        // escape if the value of newState is never adjusted
        if (newState == null) { return; }

        currentState.Notification(GC.NOTIFY_EXIT_STATE);
        currentState = newState;
        currentState.Notification(GC.NOTIFY_ENTER_STATE);
    }
}
