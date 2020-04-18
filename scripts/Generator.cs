using Godot;
using System;

public class Generator : Node2D
{
    public MainSystemState state = MainSystemState.Active;

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
                break;

            case MainSystemState.Disabled:
                break;
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
