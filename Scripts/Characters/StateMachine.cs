using Godot;
using System;

public partial class StateMachine : Node
{
    [ExportGroup("State Machine")]
    [Export] private Node currentState;
    [Export] private Node[] states;
    private Player player;

    public override void _Ready()
    {
        currentState.Notification(5001);
    }

    public void SwitchState<T>() 
    {
        Node newState = null;

        foreach (Node state in states) {
            if (state is T) {
                newState = state;
            }
        }

        // escape if the value of newState is never adjusted
        if (newState == null) { return; }

        currentState = newState;
        currentState.Notification(5001);
    }
}
