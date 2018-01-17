using Godot;
using System;

public class PlayerController : KinematicBody2D
{
	private const float force = 250;
	private Vector2 gravity = new Vector2(0, 250);

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }

    public override void _Process(float delta)
    {
        // Called every frame. Delta is time since last frame.
        // Update game logic here.
        
		Vector2 moveDir = new Vector2(0,0);
		
		if (Input.IsActionPressed("character_left"))
		{
			moveDir += new Vector2(-1, 0);
		}
		if (Input.IsActionPressed("character_right"))
		{
			moveDir += new Vector2(1, 0);
		}
		
		MoveAndCollide(gravity * delta);
		MoveAndCollide(moveDir * force * delta);
    }
	
}