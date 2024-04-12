using Godot;
using System;

public partial class TreasureChest : StaticBody3D
{
    [Export] private Area3D areaNode;
    [Export] private Sprite3D sprite;
    [Export] private RewardResource reward;

    public override void _Ready()
    {
        areaNode.BodyEntered += (body) => sprite.Visible = true;
        areaNode.BodyExited += (body) => sprite.Visible = false;
    }

    public override void _Input(InputEvent @event)
    {
        // Escape Clause
        if (!areaNode.Monitoring ||
            !areaNode.HasOverlappingBodies() || 
            !Input.IsActionJustPressed(GC.INPUT_INTERACT)) { return; }

        areaNode.Monitoring = false;
        GameEvents.RaiseReward(reward);
    }
}
