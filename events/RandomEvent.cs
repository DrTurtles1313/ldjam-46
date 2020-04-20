using Godot;
using System;

public class RandomEvent : VBoxContainer
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	VBoxContainer prompt;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		prompt = GetNode<VBoxContainer>("Init");
	}

	private void ChoicePressed(int choice, EventEffect effect, float number)
	{
		prompt.Hide();
		GetNode<VBoxContainer>(String.Format("Outcome{0}", choice)).Visible = true;
		GetNode<EventSystem>("../../..").ProcessEvent(effect, number);
	}

	private void exit()
	{
		GetNode<Control>("..").Hide();
		this.QueueFree();	
	}
}
