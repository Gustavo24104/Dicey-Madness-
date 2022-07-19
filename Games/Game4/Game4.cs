using Godot;
using System;

public class Game4 : Node
{
   [Signal]
   public delegate void arrumado();

   public override void _Process(float delta) {
      if (playerVars.killedDiceGame4 == 4) {
         EmitSignal(nameof(arrumado));
      }
   }
}
