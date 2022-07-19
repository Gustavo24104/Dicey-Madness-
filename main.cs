using Godot;
using System;
using System.Diagnostics;
using System.Net.Mime;

public class main : Node
{

	[Export] private PackedScene[] microGames;
	private Timer _microGamerTimer;
	[Export] public int score;
	private Label _scoreLabel;
	private Node curGame;
	[Export] public int lives;
	private int _lastGame;

	[Signal]
	public delegate void hider();

	[Signal]
	public delegate void show();

	[Signal]
	public delegate void loseLife();

	[Signal]
	public delegate void passed();
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		//score = GetNode<playerVars>("root/playerVars.cs").score;
		_microGamerTimer = GetNode<Timer>("MicroGameTimer");
		_scoreLabel = GetNode<Label>("ScoreLabel");
		_scoreLabel.Show();
	}
	
	
	public void EndGame() {
		GD.Print("Aqui tbm");
		if (curGame != null) {
			score++;
			_scoreLabel.Text = score.ToString();
			EmitSignal(nameof(show));
			EmitSignal(nameof(passed));
			curGame.QueueFree();
			_scoreLabel.Show();
			_microGamerTimer.Start();
		}
	}


	public void MicroGamerTimeout() {
		EmitSignal(nameof(hider));
		var i = (int) GD.RandRange(0, microGames.Length);
		if (_lastGame == i) {
			MicroGamerTimeout();
		}
		else {
			curGame = microGames[i].Instance();
			GetTree().Root.AddChild(curGame);
			curGame.Connect("FailGame", this, nameof(FailGame));
			curGame.Connect("CompleteGame", this, nameof(EndGame));
			_microGamerTimer.Stop();
			// score++;
			// _scoreLabel.Text = score.ToString();
			_scoreLabel.Hide();
			_lastGame = i;
			if (playerVars.timer > 2.2f) {
				playerVars.timer -= 0.3f;
			}

			if (playerVars.knifeSpeed < 8) {
				playerVars.knifeSpeed += .2f;
			} 
		}
	}
	


	
	public void FailGame() {
		lives--;
		GD.Print(lives);
		_scoreLabel.Show();
		curGame.QueueFree();
		_microGamerTimer.Start();
		EmitSignal(nameof(show));
		EmitSignal(nameof(loseLife));
		
		if (lives <= 0) {
			playerVars.score = score;	
			GetTree().ChangeScene("res://Scenes/GameOver/Game Over scene.tscn");
		}
	}
	
}

