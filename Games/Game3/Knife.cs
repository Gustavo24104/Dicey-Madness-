using Godot;
using System;

public class Knife : Sprite
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	private void _on_Area2D_area_entered(object area)
	{
		if (area is DiceLogic dl) {
			GD.Print("barulho de faca");
			GetNode<AudioStreamPlayer>("cut").Play();
			dl.QueueFree();
		}
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta) {
		Position = new Vector2(Position.x, GetGlobalMousePosition().y);
	}
}



