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
    public MainSystemState state = MainSystemState.Idle;
    public abstract int idlePowerConsumption { get; set; }
    public abstract int activePowerConsumption { get; set; }
    public Generator generator;

    public abstract int GetPowerConsumption();

    public override void _Ready()
    {
        
    }

    /// Switch state to active, return false if not possible
    public bool Active()
    {
        generator = GetNode<Generator>("../Generator");
        switch (state)
        {
            case MainSystemState.Broken:
            case MainSystemState.Active:
                return false;
            case MainSystemState.Idle:
                if (activePowerConsumption - idlePowerConsumption <= generator.remainingPower)
                {
                    state = MainSystemState.Active;
                    generator.CalculateRemainingPower();
                    return true;
                }
                else
                {
                    return false;
                }
            case MainSystemState.Disabled:
                if (activePowerConsumption <= generator.GetPowerConsumption())
                {
                    state = MainSystemState.Active;
                    generator.CalculateRemainingPower();
                    return true;
                }
                else
                {
                    return false;
                }
        }

        return false;
    }

    /// Set system state to idle. return false if not possible
    public bool Idle()
    {
        switch (state)
        {
            case MainSystemState.Broken:
            case MainSystemState.Idle:
                return false;
            case MainSystemState.Active:
                state = MainSystemState.Idle;
                generator.CalculateRemainingPower();
                return true;
            case MainSystemState.Disabled:
                if (idlePowerConsumption <= generator.remainingPower)
                {
                    state = MainSystemState.Active;
                    generator.CalculateRemainingPower();
                    return true;
                }
                else
                {
                    return false;
                }
        }

        return false;
    }

    /// sets the system state to disabled, returns false if not possible;
    public bool Disabled()
    {
        switch (state)
        {
            case MainSystemState.Active:
            case MainSystemState.Idle:
                state = MainSystemState.Disabled;
                generator.CalculateRemainingPower();
                return true;
            case MainSystemState.Disabled:
            case MainSystemState.Broken:
                return false;
        }

        return false;
    }

    ///Sets the system state to broken, returns false if not possible;
    public bool Broken()
    {
        switch (state)
        {
            case MainSystemState.Active:
            case MainSystemState.Idle:
            case MainSystemState.Disabled:
                state = MainSystemState.Broken;
                generator.CalculateRemainingPower();
                return true;
            case MainSystemState.Broken:
                return false;
        }
        return false;
    }
}
