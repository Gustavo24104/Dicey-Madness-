using Godot;
using System;

public class DiceScript : RigidBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	private Vector2 _force;
	[Export] private Vector2 appliedForce;
	[Export] float appliedTorque;
	private float _torque;



	public override void _Ready() {
		playerVars.deadDice = 0;
	}

	public void GoFly() {
		 _force = appliedForce;
		 ApplyImpulse(Vector2.Zero, _force);
		 GD.Print("inside the thing" + Name);
	 }

	 public void Die() {
		 playerVars.deadDice++;
		 QueueFree();	
	 }

}




