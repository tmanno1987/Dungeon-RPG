using Godot;
using System;

public partial class StatLabel : Label
{
    [Export] public StatResource TheStat;

    public override void _Ready()
    {
        TheStat.OnUpdate += HandleUpdate;

        Text = TheStat.StatValue.ToString();
    }

    private void HandleUpdate()
    {
        Text = TheStat.StatValue.ToString();
    }
}
