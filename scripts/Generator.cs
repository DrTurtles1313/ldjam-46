using Godot;
using System;

public class Generator : MainSystem
{
    public override int idlePowerConsumption {get; set;}
    public override int activePowerConsumption {get; set;}

    public float efficiency = 1f;

    public float activeBoost = 1.5f;
    public int basePower = 10;

    public int remainingPower;
    public int maxPower = 10;

    public int baseFuelConsumption = 1;
    public int activeFuelConsumption = 3;

    public void Tick()
    {
        switch (state)
        {
            case MainSystemState.Idle:
                maxPower = (int)(basePower * efficiency);
                break;

            case MainSystemState.Active:
                maxPower = (int)(basePower * efficiency * activeBoost);
                break;

            case MainSystemState.Disabled:
                break;

            case MainSystemState.Broken:
                break;
        }
    }

    public override int GetPowerConsumption()
    {
        return 0;
    }

    public void CalculateRemainingPower()
    {
        int powerConsumption = 0;
        foreach (MainSystem e in GetTree().GetNodesInGroup("MainSystems"))
        {
            powerConsumption += e.GetPowerConsumption();          
        }

        remainingPower = maxPower - powerConsumption;
        GD.Print(powerConsumption, ", ", remainingPower, "/", maxPower);
    }
}
