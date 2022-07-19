using Godot;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing.Printing;

public class DiceDraggedByMouse : Sprite
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	private bool _getDragged;
	private bool _mouveOver;
	
	
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		GD.Randomize();
		playerVars.killedDiceGame4 = 0;
	}	

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	  if (Input.IsActionJustPressed("m1") && _mouveOver && !_getDragged) {
		  _getDragged = true;
		  GetNode<AudioStreamPlayer>("../click").Play();
	  }

		  if (_getDragged) {
		  Position = GetGlobalMousePosition();
	  }      
  }

  
  private void _on_Area2D_mouse_entered() {
	  _mouveOver = true;
  }
  
  private void _on_Area2D_mouse_exited() {
	  _mouveOver = false;
  }
  
  private void _on_A_area_entered(object area) {
	  playerVars.killedDiceGame4++;
	  QueueFree();
  }

  

}


