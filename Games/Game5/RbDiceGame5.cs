using Godot;
using System;

public class RbDiceGame5 : RigidBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private bool _mouseOver;
	[Export] private AnimatedSprite myAnimator;
	private Timer winTimer;
	private Timer _endTimer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Randomize();
		myAnimator = GetNode<AnimatedSprite>("AnimatedSprite");
		winTimer = GetNode<Timer>("../WinTimer");
		_endTimer = GetNode<Timer>("../EndTimer");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if (Input.IsActionJustReleased("m1") && _mouseOver) {
			ApplyImpulse(Vector2.Zero, 
				new Vector2((float) GD.RandRange(1, 150), (float)GD.RandRange(1, 150)) 
				* 30);
			_mouseOver = false;
			myAnimator.Frame = 0;
			myAnimator.Play();
			winTimer.Start();
			_endTimer.Stop();
			GetNode<AudioStreamPlayer>("click").Play();
		}
	}
	
	

private void _on_Area2D_mouse_exited()
{
	_mouseOver = false;
}


private void _on_Area2D_mouse_entered()
{
	_mouseOver = true;
}

}
