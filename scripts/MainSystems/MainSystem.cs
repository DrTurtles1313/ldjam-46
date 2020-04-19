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
    public MainSystemState lastState = MainSystemState.Idle;
    public abstract int idlePowerConsumption { get; set; }
    public abstract int activePowerConsumption { get; set; }
    public abstract float efficiency {get; set;}
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
                    lastState = state;
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
                    lastState = state;
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
        generator = GetNode<Generator>("../Generator");
        switch (state)
        {
            case MainSystemState.Broken:
            case MainSystemState.Idle:
                return false;
            case MainSystemState.Active:
                lastState = state;
                state = MainSystemState.Idle;
                generator.CalculateRemainingPower();
                return true;
            case MainSystemState.Disabled:
                if (idlePowerConsumption <= generator.remainingPower)
                {
                    lastState = state;
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
        generator = GetNode<Generator>("../Generator");
        switch (state)
        {
            case MainSystemState.Active:
            case MainSystemState.Idle:
                lastState = state;
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
        generator = GetNode<Generator>("../Generator");
        switch (state)
        {
            case MainSystemState.Active:
            case MainSystemState.Idle:
            case MainSystemState.Disabled:
                lastState = state;
                state = MainSystemState.Broken;
                generator.CalculateRemainingPower();
                return true;
            case MainSystemState.Broken:
                return false;
        }
        return false;
    }

    public void Repair()
    {
        state = MainSystemState.Disabled;
    }

    public void ChangeEfficiency(float change)
    {
        efficiency += change;
        GD.Print(efficiency);
    }
}
