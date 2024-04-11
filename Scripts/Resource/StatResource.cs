using Godot;
using System;

[GlobalClass]
public partial class StatResource : Resource
{
    // Keep track of stat and its value
    public event Action OnZero;
    public event Action OnUpdate;
    [Export] public Stat StatType { get; private set; }
    [Export] public float MaxStatValue { get; private set; }
    private float _statValue;

    [Export]
    public float StatValue
    {
        get => _statValue;
        set 
        {
            _statValue = Mathf.Clamp(value, 0, MaxStatValue);

            OnUpdate?.Invoke();

            if (_statValue <= 0) {
                OnZero?.Invoke();
            }
        }
    }
}