using Godot;
using System.Collections.Generic;

public enum EventEffect
{
	None,
	GeneratorEfficiency,
	ReplicatorEfficiency,
	ScoopEfficiency,
	FabricatorEfficiency,
	Parts,
	Nanites,
	Fuel,
	DataTime,
}

public enum EventType
{
	Transit,
	Warp,
	Star,
	Planet,
	Passerby
}

public class EventSystem : Control
{
	VBoxContainer container;
	Label eventText;
	Popup popup;

	List<List<PackedScene>> EventTypes = new List<List<PackedScene>>();
	RandomEvent currentEvent;

	List<PackedScene> TransitEvents = new List<PackedScene>();
	List<PackedScene> WarpEvents = new List<PackedScene>();
	List<PackedScene> StarEvents = new List<PackedScene>();
	List<PackedScene> PlanetEvents = new List<PackedScene>();
	List<PackedScene> PasserbyEvents = new List<PackedScene>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
 		popup = GetNode<Popup>("Event(L4)/Popup");

		TransitEvents.Add((PackedScene)GD.Load("res://events/Transit/0.tscn"));

		EventTypes.Add(TransitEvents);
		EventTypes.Add(WarpEvents);
		EventTypes.Add(StarEvents);
		EventTypes.Add(PlanetEvents);
		EventTypes.Add(PasserbyEvents);
	}

	public void GenerateEvent(EventType type, int number)
	{
		popup.PopupCentered();
		currentEvent = (RandomEvent)EventTypes[(int)type][number].Instance();
		popup.AddChild(currentEvent);
	}

	public void ProcessEvent(EventEffect effect, float value)
	{
		switch (effect)
		{
			case EventEffect.Parts:
				Storage storage = GetNode<Storage>("../Storage");
				if (storage.AddParts(value)) { break; }
				else
				{
					storage.AddParts(storage.size - storage.usedSpace);
					break;
				}
			case EventEffect.None:
			default:
				break;
		}
	}
}
