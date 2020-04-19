using Godot;
using System;

public class GUI : MarginContainer
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private Label fuelNumber;
	private Label nanitesNumber;
	private Label partsNumber;
	private Label powerNumber;
	private Label storageNumber;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		fuelNumber = GetNode<Label>("Top/Fuel/Number");
		nanitesNumber = GetNode<Label>("Top/Nanites/Number");
		partsNumber = GetNode<Label>("Top/Parts/Number");
		powerNumber = GetNode<Label>("Top/Power/Number");
		storageNumber = GetNode<Label>("Top/Storage/Number");
	}

	private void _on_Storage_OnNaniteChange(float Nanites, float usedSpace, float size)
	{
		nanitesNumber.Text = Nanites.ToString();
		storageNumber.Text = String.Format("{0}/{1}", usedSpace, size);
	}

	private void _on_Storage_OnPartsChange(float Parts, float usedSpace, float size)
	{
		partsNumber.Text = Parts.ToString();
		storageNumber.Text = String.Format("{0}/{1}", usedSpace, size);
	}

	private void _on_Storage_OnFuelChange(float Fuel, float usedSpace, float size)
	{
		fuelNumber.Text = Fuel.ToString();
		storageNumber.Text = String.Format("{0}/{1}", usedSpace, size);
	}

	private void _on_Storage_PowerChanged(int powerConsumption, int maxPower)
	{
		powerNumber.Text = String.Format("{0}/{1}", powerConsumption, maxPower);
	}
}
