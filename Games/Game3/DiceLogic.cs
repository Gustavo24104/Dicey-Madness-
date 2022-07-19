using Godot;
using System;

public class DiceLogic : Area2D
{

    [Export] private float speed;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        speed = playerVars.knifeSpeed;
    }

    public override void _PhysicsProcess(float delta) {
        Position += Vector2.Left * speed;
    }
}
