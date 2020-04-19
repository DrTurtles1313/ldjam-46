using Godot;
using System;

public enum PlayerState
{
	Idle,
	Minigame,
	Bridge
}

public enum Minigame
{
	Replicator,
	Fabricator,
	Generator,
	Scoop
}

public class PlayerController : KinematicBody2D
{
	public PlayerState state = PlayerState.Idle;
	public int Speed = 200;

	bool InReplicatorRoom = false;
	bool InFabricatorRoom = false;
	bool InGeneratorRoom = false;
	bool InScoopRoom = false;

	Vector2 velocity = new Vector2();

	public void GetInput()
	{
		
		velocity = new Vector2();

		if (Input.IsActionPressed("right"))
			velocity.x += 1;

		if (Input.IsActionPressed("left"))
			velocity.x -= 1;

		if (Input.IsActionPressed("down"))
			velocity.y += 1;

		if (Input.IsActionPressed("up"))
			velocity.y -= 1;

		velocity = velocity.Normalized() * Speed;
	}

	[Signal]
	public delegate void MinigameSignal(int difficultyLevel);

	public override void _PhysicsProcess(float delta)
	{
		switch (state)
		{
			case PlayerState.Idle:
				GetInput();
				velocity = MoveAndSlide(velocity);
				break;
			default:
				break;
		}
	}

	public void OnMinigameExit(int SuccessState)
	{
		GD.Print("exit minigame CS SuccessState", SuccessState);
		state = PlayerState.Idle;
	}


	public void OnSystemInteract(int system)
	{
		switch (system)
		{
			case (int)Minigame.Fabricator:
				if (InFabricatorRoom)
				{
					state = PlayerState.Minigame;
					var scene = (PackedScene)GD.Load("res://Minigame.tscn");
					var node = scene.Instance();
					this.Connect("MinigameSignal", node, "_on_minigame_enter");
					node.Connect("minigame_exit", this, nameof(OnMinigameExit));
					AddChild(node);
					EmitSignal(nameof(MinigameSignal), 1);
				}
				break;

			case (int)Minigame.Generator:
				if (InGeneratorRoom)
				{
					state = PlayerState.Minigame;
					var scene = (PackedScene)GD.Load("res://Minigame.tscn");
					var node = scene.Instance();
					this.Connect("MinigameSignal", node, "_on_minigame_enter");
					node.Connect("minigame_exit", this, nameof(OnMinigameExit));
					AddChild(node);
					EmitSignal(nameof(MinigameSignal), 1);
				}
				break;

			case (int)Minigame.Replicator:
				if (InReplicatorRoom)
				{
					state = PlayerState.Minigame;
					var scene = (PackedScene)GD.Load("res://Minigame.tscn");
					var node = scene.Instance();
					this.Connect("MinigameSignal", node, "_on_minigame_enter");
					node.Connect("minigame_exit", this, nameof(OnMinigameExit));
					AddChild(node);
					EmitSignal(nameof(MinigameSignal), 1);
				}
				break;

			case (int)Minigame.Scoop:
				if (InGeneratorRoom)
				{
					state = PlayerState.Minigame;
					var scene = (PackedScene)GD.Load("res://Minigame.tscn");
					var node = scene.Instance();
					this.Connect("MinigameSignal", node, "_on_minigame_enter");
					node.Connect("minigame_exit", this, nameof(OnMinigameExit));
					AddChild(node);
					EmitSignal(nameof(MinigameSignal), 1);
				}
				break;

			default:
				break;
		}
		
	}

	private void OnRoomEntered(object body, int room, bool entered)
	{
		if (entered)
		{
			switch (room)
			{
				case (int)Minigame.Fabricator:
					GD.Print("entered Fabricator room");
					InFabricatorRoom = true;
					break;
				case (int)Minigame.Generator:
					GD.Print("entered Generator room");
					InGeneratorRoom = true;
					break;
				case (int)Minigame.Replicator:
					GD.Print("entered replicator room");
					InReplicatorRoom = true;
					break;
				case (int)Minigame.Scoop:   
					GD.Print("entered Scoop room");
					InScoopRoom = true;
					break;
				default:
					break;
			}
		}
		else
		{
			switch (room)
			{
				case (int)Minigame.Fabricator:
					GD.Print("exited Fabricator room");
					InFabricatorRoom = false;
					break;
				case (int)Minigame.Generator:
					GD.Print("exited Generator room");
					InGeneratorRoom = false;
					break;
				case (int)Minigame.Replicator:
					GD.Print("exited Replicator room");
					InReplicatorRoom = false;
					break;
				case (int)Minigame.Scoop:
					GD.Print("exited Scoop room");   
					InScoopRoom = false;
					break;
				default:
					break;
			}
		}	
	}
}
