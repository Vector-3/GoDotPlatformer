using Godot;
using System;

public class PlayerController : KinematicBody2D
{
	private const float walkSpeed = 250;
	private Vector2 gravity = new Vector2(0, 250);
	private bool debugMode = true;
	private RichTextLabel debugLabel; 
	private Vector2 velocity = new Vector2(0,0);
	
    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        debugLabel = (RichTextLabel)GetNode("/root/Scene/CanvasLayer/DebugLabel");
    }

    public override void _Process(float delta)
    {
        // Called every frame. Delta is time since last frame.
        // Update game logic here.
		
        if (debugMode && debugLabel != null) 
		{
			debugLabel.Text = "X: " + GetPosition().x.ToString("0") + ", Y: " + GetPosition().y.ToString("0");
			debugLabel.Text += "\nCell X: " + (GetPosition().x / 32).ToString("0") + ", Cell Y: " + (GetPosition().y / 32).ToString("0");
			debugLabel.Text += "\n\nOnFloor: " + IsOnFloor();
			debugLabel.Text += "\nOnWall: " + IsOnWall();
		}
    }

	public override void _PhysicsProcess(float delta) 
	{
		
		velocity += gravity * delta;
		
		if (Input.IsActionPressed("character_left"))
		{
			velocity.x = -walkSpeed;
		}
		else if (Input.IsActionPressed("character_right"))
		{
			velocity.x = walkSpeed;
		}
		else
		{
			velocity.x = 0;
		}
		
		var motion = velocity * delta;
		
		MoveAndSlide(velocity);
		
	}
	
}