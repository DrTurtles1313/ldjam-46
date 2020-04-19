using Godot;
using System.Collections.Generic;

public class Storage : Node2D
{
	public int size = 50;
	private List<int> storage = new List<int>();
	public int nanites = 0;
	public int fuel = 0;
	public int parts = 0;

	[Signal]
	public delegate void OnNaniteChange(int Nanites);
	
	[Signal]
	public delegate void OnPartsChange(int Parts);
	
	[Signal]
	public delegate void OnFuelChange(int Fuel);

	public bool AddParts(int amount)
	{
		if (storage.Count + amount < size)
		{
			for (int i = 0; i < amount; i++)
			{
				storage.Add(0);
				parts++;
			}
			EmitSignal(nameof(OnPartsChange), parts);
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool AddNanites(int amount)
	{
		if (storage.Count + amount < size)
		{
			for (int i = 0; i < amount; i++)
			{
				storage.Add(1);
				nanites++;
			}
			EmitSignal(nameof(OnNaniteChange), nanites);
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool AddFuel(int amount)
	{
		if (storage.Count + amount < size)
		{
			for (int i = 0; i < amount; i++)
			{
				storage.Add(2);
				fuel++;
			}
			EmitSignal(nameof(OnFuelChange), fuel);
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool RemoveParts(int amount)
	{
		if (storage.Contains(0))
		{
			for (int i = 0; i < amount; i++)
			{
				storage.Remove(0);
				parts--;
			}
			EmitSignal(nameof(OnPartsChange), parts);
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool RemoveNanites(int amount)
	{
		if (storage.Contains(1))
		{
			for (int i = 0; i < amount; i++)
			{
				storage.Remove(1);
				nanites--;
			}
			EmitSignal(nameof(OnNaniteChange), nanites);
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool RemoveFuel(int amount)
	{
		if (storage.Contains(2))
		{
			for (int i = 0; i < amount; i++)
			{
				storage.Remove(2);
				fuel--;
			}
			EmitSignal(nameof(OnFuelChange), fuel);
			return true;
		}
		else
		{
			return false;
		}
	}
}
