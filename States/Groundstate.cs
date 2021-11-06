using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundstate : AbState
{
    public Groundstate(MyPlayer myp, action a) : base(myp, a) { }

    public override void ActionMove()
    {
        if (!act.isground())
        {
            myPlayer.Setstate(new AirState(myPlayer,act));
            return;
        }
        act.Move();
        act.Dash();
        act.jump();
    }
}
