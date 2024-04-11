using Godot;
using System;

public partial class EnemiesContainer : Node3D
{
    public override void _Ready()
    {
        int enemyCount = GetChildCount();
        GameEvents.RaiseNewEnemyCount(enemyCount);
        ChildExitingTree += HandleChildExitingTree;
    }

    private void HandleChildExitingTree(Node node)
    {
        int enemyCount = GetChildCount() - 1;
        GameEvents.RaiseNewEnemyCount(enemyCount);

        if (enemyCount == 0) {
            GameEvents.RaiseVictory();
        }
    }
}
