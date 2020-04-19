using Godot;
using System;

public class Fabricator : MainSystem
{
    public float efficiency = 1f;
    public int failureReduction = 20;

    public override int idlePowerConsumption {get; set;}
    public override int activePowerConsumption {get; set;}

    public override void _Ready()
    {
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
                GetNode<Storage>("../Storage").AddParts((int)(2 * efficiency));
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
