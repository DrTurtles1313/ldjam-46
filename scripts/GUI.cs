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

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		fuelNumber = GetNode<Label>("Top/Fuel/Number");
		nanitesNumber = GetNode<Label>("Top/Nanites/Number");
		partsNumber = GetNode<Label>("Top/Parts/Number");
	}

	private void _on_Storage_OnNaniteChange(int Nanites)
	{
		nanitesNumber.Text = Nanites.ToString();
	}

	private void _on_Storage_OnPartsChange(int Parts)
	{
		fuelNumber.Text = Parts.ToString();
	}

	private void _on_Storage_OnFuelChange(int Fuel)
	{
		partsNumber.Text = Fuel.ToString();
	}
}



