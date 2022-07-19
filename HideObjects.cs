using Godot;
using System;

public class HideObjects : Node
{
	
	private void _on_MainGame_hider() {
		GetNode(this.GetPath()).Set("visible", false);
	}




	private void _on_MainGame_show()
	{
		GetNode(this.GetPath()).Set("visible", true);
	}

	
	private void _on_MainGame_loseLife() {
		GetNode<AnimationPlayer>("AnimationPlayer").Play("shake");
		GetNode<AudioStreamPlayer>("audio").Play();
		GetChild(0).QueueFree();
		

	}
	
	

}
