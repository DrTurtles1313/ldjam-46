using Godot;
using System;

public class Fabricator : MainSystem
{
    public int failureReduction = 20;

    public override int idlePowerConsumption {get; set;}
    public override int activePowerConsumption {get; set;}
    public override float efficiency {get; set;}

    public override void _Ready()
    {
        efficiency = 1f;
        idlePowerConsumption = 3;
        activePowerConsumption = 5;
    }

    public void Tick()
    {
        switch (state)
        {
            case MainSystemState.Idle:
                failureReduction = 20;
                break;

            case MainSystemState.Active:
                failureReduction = 25;
                GetNode<Storage>("../Storage").AddParts(2 * efficiency);
                break;

            case MainSystemState.Disabled:
                failureReduction = 0;
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
