using Godot;
using System;

public class Tick : Node2D
{
    public void OnTimerTimeout()
    {
        GetTree().CallGroup("MainSystems", "Tick");
    }
}
