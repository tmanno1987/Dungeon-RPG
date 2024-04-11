using Godot;
using System;

public partial class EnemyCountLabel : Label
{
    public override void _Ready()
    {
        GameEvents.OnNewEnemyCount += HandleEnemyNewCount;
    }

    private void HandleEnemyNewCount(int count)
    {
        Text = count.ToString();
    }
}
