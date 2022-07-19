using Godot;
using System;

public class Blower :AnimatedSprite
{



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta) {
		Position = GetGlobalMousePosition();
	}
	
	

	private void _on_Area2D_body_entered(object body)
	{
		if (body is DiceScript ds) {
			ds.GoFly();
		}
	}
	
	
}





