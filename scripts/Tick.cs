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
		
	}

	public void SystemFailure()
	{
		int failure = random.Next(100);
		if (failure > failureRate - GetNode<Fabricator>("../Fabricator").failureReduction)
		{
			switch (random.Next(3))
			{
				case 0:
					GetNode<Fabricator>("../Fabricator").Broken();
					GD.Print("Fabricator Broken");
					break;
				case 1:
					GetNode<Replicator>("../Replicator").Broken();
					GD.Print("Replicator Broken");
					break;
				case 2:
					GetNode<Scoop>("../Scoop").Broken();
					GD.Print("Scoop Broken");
					break;
				case 3:
					GetNode<Generator>("../Generator").Broken();
					GD.Print("Generator Broken");
					GetTree().CallGroup("MainSystems", "Disabled");
					break;
				default:
					break;
			}
		}
		else
		{
			GD.Print("No System Failure This Tick");
		}   
	}
}
