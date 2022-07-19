using Godot;
using System;
using System.ComponentModel;
using System.Net.Mime;

public class MainMenuButons : Control
{

	[Export] public PackedScene mainScene;
	[Export] private PackedScene tutorialScene;


   private void PressPlay() {
	   GetTree().ChangeScene(mainScene.ResourcePath);
	   playerVars.timer = 4.5f;
	   playerVars.knifeSpeed = 4f;
   }


	private void _on_QuitBtn_pressed()
	{
		GetTree().Quit();
	}
	
	
	


	private void btnHowTo() {
		GetTree().ChangeScene(tutorialScene.ResourcePath);
	}

	
	
	
}
