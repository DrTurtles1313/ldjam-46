using Godot;
using System;

public class Replicator : MainSystem
{
    public MainSystemState state = MainSystemState.Idle;
    
    public int idlePowerConsumption = 3;
    public int activePowerConsumption = 5;

    public void Tick()
    {
        switch (state)
        {
            case MainSystemState.Idle:
                break;

            case MainSystemState.Active:
                GetNode<Storage>("../Storage").AddFood();
                break;

            case MainSystemState.Disabled:
                break;
        }
    }

    public override int GetPowerConsumption()
    {
        switch (state)
        {
            case MainSystemState.Idle:
                return idlePowerConsumption;
            case MainSystemState.Active:
                return activePowerConsumption;
            case MainSystemState.Broken:
            case MainSystemState.Disabled:
                return 0;
        }
        return 0;
    }
}
