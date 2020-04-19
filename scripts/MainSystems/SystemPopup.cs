using Godot;
using System;

public class SystemPopup : Container
{
	private Label statusLabel;
	private Label efficiencyLabel;
	private Label label;
	private Button activeButton;
	private Button idleButton;
	private Button disabledButton;
	
	public override void _Ready()
	{
		statusLabel = GetNode<Label>("Container/Status/state");
		efficiencyLabel = GetNode<Label>("Container/Efficiency/Number");
		activeButton = GetNode<Button>("Container/Buttons/Active");
		disabledButton = GetNode<Button>("Container/Buttons/Disabled");
		idleButton = GetNode<Button>("Container/Buttons/Idle");
		Node parent = GetParent();
		label = GetNode<Label>("Container/Label");
		label.Text = parent.Name;
		activeButton.Connect("pressed", parent, "Active");
		disabledButton.Connect("pressed", parent, "Disabled");
		idleButton.Connect("pressed", parent, "Idle");
		
	}

	private void OnStateChanged(MainSystemState state)
	{
		statusLabel.Text = state.ToString();
	}

	private void OnEfficiencyChanged(float efficiency)
	{
		efficiencyLabel.Text = String.Format("{0}%", efficiency * 100);
	}

	private void _on_Area2D_body_entered(object body)
	{
		this.Visible = true;
	}


	private void _on_Area2D_body_exited(object body)
	{
		this.Visible = false;
	}
}
