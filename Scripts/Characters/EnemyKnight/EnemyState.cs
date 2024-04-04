using Godot;

public abstract partial class EnemyState : CharacterState
{
    protected Vector3 destination;

    protected void UpdateDestination(int num) 
    {
        // updates the characters destination.
        Vector3 localPos = player.PathNode.Curve.GetPointPosition(num);
        Vector3 globalPos = player.PathNode.GlobalPosition;
        destination = localPos + globalPos;
    }

    protected void Move()
    {
        player.AgentNode.GetNextPathPosition();
        player.Velocity = player.GlobalPosition.DirectionTo(destination);

        player.MoveAndSlide();
        player.Flip();
    }
}