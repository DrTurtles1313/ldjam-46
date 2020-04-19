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
	Scoop,
	Null
}

public enum SuccessState
{
	NOATTEMPT, // no repair attempt was made, minigame was left
	BOTCH, // brings system online, damages efficiency
	PASSABLE, // only brings system online
	SUCCESS // brings system online, restores efficiency
}

public class PlayerController : KinematicBody2D
{
	public PlayerState state = PlayerState.Idle;
	public int Speed = 200;

	bool InReplicatorRoom = false;
	bool InFabricatorRoom = false;
	bool InGeneratorRoom = false;
	bool InScoopRoom = false;
	Minigame activeSystem = Minigame.Null;

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

	public void OnMinigameExit(SuccessState successState)
	{
		GD.Print("exit minigame CS SuccessState: ", successState);
		state = PlayerState.Idle;
		MainSystem system = GetNode<MainSystem>(String.Format("../{0}", activeSystem.ToString()));
		switch (successState)
		{
			case SuccessState.BOTCH:
				system.Repair();
				system.ChangeEfficiency(-0.2f);
				break;
			case SuccessState.SUCCESS:
				system.Repair();
				system.ChangeEfficiency(0.2f);
				break;
			case SuccessState.PASSABLE:
				system.Repair();
				break;
			case SuccessState.NOATTEMPT:
			default:
				break;
		}
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
				if (InScoopRoom)
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
					activeSystem = Minigame.Fabricator;
					InFabricatorRoom = true;
					break;
				case (int)Minigame.Generator:
					GD.Print("entered Generator room");
					activeSystem = Minigame.Generator;
					InGeneratorRoom = true;
					break;
				case (int)Minigame.Replicator:
					GD.Print("entered replicator room");
					activeSystem = Minigame.Replicator;
					InReplicatorRoom = true;
					break;
				case (int)Minigame.Scoop:   
					GD.Print("entered Scoop room");
					activeSystem = Minigame.Scoop;
					InScoopRoom = true;
					break;
				default:
					break;
			}
		}
		else
		{
			activeSystem = Minigame.Null;
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
