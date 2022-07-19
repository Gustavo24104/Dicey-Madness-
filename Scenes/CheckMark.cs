	using Godot;
using System;

public class CheckMark : AnimatedSprite
{
	public override void _Ready() {
		Hide();
	}

	
	private void _on_MainGame_passed()
	{
		Show();
		Frame = 0;
		Play("default", false);
		GetNode<AudioStreamPlayer>("Correct").Play();
	}
	
	

	private void _on_MainGame_hider()
	{
		Hide();
	}


	
}




