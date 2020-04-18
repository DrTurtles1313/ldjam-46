using Godot;
using System;

public enum MainSystemState
{
    Idle,
    Active,
    Disabled,
    Broken
}

public abstract class MainSystem : Node2D
{
    

    public abstract int GetPowerConsumption(); 
}
