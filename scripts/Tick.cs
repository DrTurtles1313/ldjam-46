using Godot;
using System;

public class Tick : Node2D
{
    int failureRate = 40;
    Random random = new Random();

    public void OnTimerTimeout()
    {
        GetNode<Generator>("../Generator").CalculateRemainingPower();
        GetTree().CallGroup("MainSystems", "Tick");
        int failure = random.Next(100);
        if (failure > failureRate - GetNode<Fabricator>("../Fabricator").failureReduction)
        {
            SystemFailure();
        }
    }

    public void SystemFailure()
    {
        switch (random.Next(3))
            {
                case 0:
                    GetNode<Fabricator>("../Fabricator").Broken();
                    break;
                case 1:
                    GetNode<Replicator>("../Replicator").Broken();
                    break;
                case 2:
                    GetNode<Scoop>("../Scoop").Broken();
                    break;
                case 3:
                    GetNode<Generator>("../Generator").Broken();
                    GetTree().CallGroup("MainSystems", "Disabled");
                    break;
                default:
                    break;
            }
    }
}
