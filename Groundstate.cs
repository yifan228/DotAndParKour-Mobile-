using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundstate : AbState
{
    public Groundstate(MyPlayer myp, action a) : base(myp, a) {
        if (a is actionMobile)
        {
            ((actionMobile)a).groundJumpbtn.SetActive(true);
            ((actionMobile)a).grabbtn.SetActive(false);
        }
    }

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
