using Godot;
using System;
using System.Diagnostics;

public class GameTest : Node
{
	private Timer _endTimer;

	[Signal]
	public delegate void FailGame();

	[Signal]
	public delegate void CompleteGame();
	
	
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		_endTimer = GetNode<Timer>("EndTimer");
		_endTimer.WaitTime = playerVars.timer;
		GD.Print("tempo do timer: " + _endTimer.WaitTime);
		GD.Print("Tempo do playervar: " + playerVars.timer);
		_endTimer.Start();
	}

	private void _on_EndTimer_timeout()
	{
		EmitSignal(nameof(FailGame));
	}
	
	
	private void endTimerBom()
	{
		GD.Print("aqui");
		EmitSignal(nameof(CompleteGame));
	}
	

	private void onSucces()
	{
		GD.Print("aqui");
		EmitSignal(nameof(CompleteGame));
	}

	private void _on_buraconegro_area_entered(object area)
	{
		GD.Print("rip aff ruinzao");
		EmitSignal(nameof(FailGame));
	}

	
	
}





