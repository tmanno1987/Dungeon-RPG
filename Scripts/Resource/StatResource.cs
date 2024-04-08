using Godot;

[GlobalClass]
public partial class StatResource : Resource
{
    // Keep track of stat and its value
    [Export] public Stat StatType { get; private set; }
    [Export] public float StatValue { get; private set; }
    [Export] public float MaxStatValue { get; private set; }
}