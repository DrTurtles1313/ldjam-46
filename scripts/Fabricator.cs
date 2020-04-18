using Godot;
using System;

public enum MainSystemState
{
    Idle,
    Active,
    Disabled,
    Broken
}

public class Fabricator : Node
{
    public MainSystemState state = MainSystemState.Active;
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void Tick()
    {
        switch (state)
        {
            case MainSystemState.Idle:
                break;

            case MainSystemState.Active:
                GetNode<Storage>("../Storage").AddParts();
                break;

            case MainSystemState.Disabled:
                break;
        }
    }

    public int GetPowerConsumption()
    {
        return 0;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
