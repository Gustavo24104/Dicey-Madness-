using Godot;
using System;

public class Game1 : Node2D
{
    private int _number1;
    private int _number2;
    private int _sum;
    [Signal] public delegate void Succes();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        GD.Randomize();
        _sum = (int) GD.RandRange(2, 12);
        GD.Print(_sum);
        GetNode<Label>("../CanvasLayer/GameLabel").Text = "Make " + _sum + "!";
        _number1 = (int) GD.RandRange(0, 6);
        _number2 = (int) GD.RandRange(0, 6);
        if (_number1 + _number2 == +_sum) {
            _Ready();
        }
    }

    

    public override void _Process(float delta) {
        
        GetNode<AnimatedSprite>("../Sprite/Spr1Anims").Frame = _number1 - 1;
        GetNode<AnimatedSprite>("../Sprite2/Spr2Anims").Frame = _number2 - 1;
        
        if (Input.IsActionJustPressed("m1")) {
            _number1 += 1;
            if (_number1 > 6) _number1 = 1;
            GetNode<AudioStreamPlayer>("click").Play();
            GD.Print(_number1);
        }

        if (Input.IsActionJustPressed("m2")) {
            _number2 += 1;
            GetNode<AudioStreamPlayer>("click").Play();
            if (_number2 > 6) _number2 = 1;    
            GD.Print(_number2);
        }
        
        if (_number1 + _number2 == +_sum) {
            //GD.Print("ganhaste");
            EmitSignal(nameof(Succes));
            GetNode<AnimatedSprite>("../Sprite/Spr1Anims").Frame = _number1 - 1;
            GetNode<AnimatedSprite>("../Sprite2/Spr2Anims").Frame = _number2 - 1;
            //SetProcess(false);
        }
    }
    
}



