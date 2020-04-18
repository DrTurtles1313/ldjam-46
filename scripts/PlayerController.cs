using Godot;
using System;

public enum PlayerState
{
    Idle,
    Minigame,
    Bridge
}

public class PlayerController : KinematicBody2D
{
    public PlayerState state = PlayerState.Idle;
    public int Speed = 200;
    bool InReplicatorRoom = false;

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

    public void OnReplicatorInteract()
    {
        if (InReplicatorRoom)
        {
            state = PlayerState.Minigame;
            //TODO: load minigame scene somehow
        }
    }

    public void ReplicatorRoomEntered(Node body)
    {
        InReplicatorRoom = true;
    }

    public void ReplicatorRoomExited(Node body)
    {
        InReplicatorRoom = false;
    }
}