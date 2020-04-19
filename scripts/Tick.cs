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
					Fabricator fabricator = GetNode<Fabricator>("../Fabricator");
					fabricator.Broken();
					fabricator.ChangeEfficiency(-0.2f);
					GD.Print("Fabricator Broken");
					break;
				case 1:
					Replicator replicator = GetNode<Replicator>("../Replicator");
					replicator.Broken();
					replicator.ChangeEfficiency(-0.2f);
					GD.Print("Replicator Broken");
					break;
				case 2:
					Scoop scoop = GetNode<Scoop>("../Scoop");
					scoop.Broken();
					scoop.ChangeEfficiency(-0.2f);
					GD.Print("Scoop Broken");
					break;
				case 3:
					Generator generator = GetNode<Generator>("../Generator");
					generator.Broken();
					generator.ChangeEfficiency(-0.2f);
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
