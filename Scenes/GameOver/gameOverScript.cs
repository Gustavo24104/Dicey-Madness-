using Godot;
using System;

public class gameOverScript : Node
{
   
	
	public override void _Ready()
	{
		GD.Print(playerVars.score);
		GetNode<Label>("scrText").Text = "But you scored: " + playerVars.score + " points!";
	}


	private void _on_Button_pressed() {
		GetTree().ChangeScene("res://Scenes/MainMenu.tscn");
	}

	
	
	
}

