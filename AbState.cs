using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbState 
{
    protected MyPlayer myPlayer;
    protected action act;
    public abstract void ActionMove();
    public AbState(MyPlayer myP,action a)
    {
        myPlayer = myP;
        act = a;
    }
}
