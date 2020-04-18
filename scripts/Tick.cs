using Godot;
using System;

public class Tick : Node2D
{
    public void OnTimerTimeout()
    {
        GetNode<Generator>("../Generator").CalculateRemainingPower();
        GetTree().CallGroup("MainSystems", "Tick");
    }
}
