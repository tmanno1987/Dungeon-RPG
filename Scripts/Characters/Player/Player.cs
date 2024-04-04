using Godot;
using System;

public partial class Player : Character
{
    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(
            GC.INPUT_MOVE_LEFT,
            GC.INPUT_MOVE_RIGHT,
            GC.INPUT_MOVE_FORWARD,
            GC.INPUT_MOVE_BACKWARD
        );
    }
}
