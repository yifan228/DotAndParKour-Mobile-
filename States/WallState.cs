using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallState : AbState
{
    public WallState(MyPlayer myp, action a) : base(myp, a) { }

    public override void ActionMove()
    {
        if (!act.InputTriggergrab()|| (!act.CanGrabLeft() && !act.CanGrabRit() && !act.IsFeetGroundLeft() && !act.IsFeetGroundRit()))
        {
            myPlayer.Setstate(new AirState(myPlayer, act));
            return;
        }
        act._myChar.gravityScale = 0;
        //jumpup
        act.Grab();
        //walljump
    }
   
}
