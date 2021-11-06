using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : AbState
{
    // MyPlayer >>myplayer
    //action >>act
    public override void ActionMove()
    {
        if (act.isground())
        {
            myPlayer.Setstate(new Groundstate(myPlayer,act));
            return;
        }else if (act.InputTriggergrab()&&(act.CanGrabLeft() || act.CanGrabRit()))
        {
            myPlayer.Setstate(new WallState(myPlayer, act));
            return;
        }
        act.Move();
        act.Dash();
        if (act._myChar.velocity.y <= 0)
        {
            act._myChar.gravityScale = 1.5f;
        }
        else
        {
            act._myChar.gravityScale = 1f;
        }
    }
    public AirState(MyPlayer myp, action a) : base(myp, a) { }
}
