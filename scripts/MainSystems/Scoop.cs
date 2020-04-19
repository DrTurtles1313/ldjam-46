using Godot;
using System;

public class Scoop : MainSystem
{
    public override int idlePowerConsumption {get; set;}
    public override int activePowerConsumption {get; set;}
    public override float efficiency {get; set;}

    public override void _Ready()
    {
        idlePowerConsumption = 3;
        activePowerConsumption = 4;
        efficiency = 1f;
    }

    public void Tick()
    {
        switch (state)
        {
            case MainSystemState.Idle:
                GetNode<Storage>("../Storage").AddFuel(1 * efficiency);
                break;

            case MainSystemState.Active:
                GetNode<Storage>("../Storage").AddFuel(2 * efficiency);
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
