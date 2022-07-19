using Godot;
using System;

public class Game2 : Node
{

	[Signal]
	public delegate void complete();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		
	}

	private void _on_Area2D_body_entered(object body)
	{
		if (body is DiceScript ds) {
			GetNode<AudioStreamPlayer>("caido").Play();
			ds.Die();
			GD.Print("RIP dados "+ playerVars.deadDice);
		}
	}


	public override void _Process(float delta) {
		if (playerVars.deadDice == 11) {
			EmitSignal(nameof(complete));
		}
	}
}


