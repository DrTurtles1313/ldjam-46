using Godot;
using System.Collections.Generic;

public class Storage : Node2D
{
	public float size = 50f;
	public float nanites = 0;
	public float fuel = 0;
	public float parts = 0;
	public float usedSpace = 0;

	[Signal]
	public delegate void OnNaniteChange(float Nanites, float usedSpace, float size);
	
	[Signal]
	public delegate void OnPartsChange(float Parts, float usedSpace, float size);
	
	[Signal]
	public delegate void OnFuelChange(float Fuel, float usedSpace, float size);

	public bool AddParts(float amount)
	{
		if (usedSpace + amount < size)
		{
			usedSpace += amount;
			parts += amount;
			EmitSignal(nameof(OnPartsChange), parts, usedSpace, size);
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool AddNanites(float amount)
	{
		if (usedSpace + amount < size)
		{
			usedSpace += amount;
			nanites += amount;
			EmitSignal(nameof(OnNaniteChange), nanites, usedSpace, size);
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool AddFuel(float amount)
	{
		if (usedSpace + amount < size)
		{
			usedSpace += amount;
			fuel += amount;
			EmitSignal(nameof(OnFuelChange), fuel, usedSpace, size);
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool RemoveParts(float amount)
	{
		if (amount <= parts)
		{
			usedSpace -= amount;
			parts -= amount;
			EmitSignal(nameof(OnPartsChange), parts, usedSpace, size);
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool RemoveNanites(float amount)
	{
		if (amount <= nanites)
		{
			usedSpace -= amount;
			nanites -= amount;
			EmitSignal(nameof(OnNaniteChange), nanites, usedSpace, size);
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool RemoveFuel(float amount)
	{
		if (amount <= fuel)
		{
			usedSpace -= amount;
			fuel -= amount;
			EmitSignal(nameof(OnFuelChange), fuel, usedSpace, size);
			return true;
		}
		else
		{
			return false;
		}
	}
}
