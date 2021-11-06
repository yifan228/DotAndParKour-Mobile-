using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseClickManger : ClickManager
{
    

    public override Vector2 ClickPos()
    {
        return Input.mousePosition;
    }

    public override bool down()
    {
        return Input.GetMouseButton(0);
    }

    public override bool downClick()
    {
        return Input.GetMouseButtonDown(0);
    }

    public override bool hover()
    {
        return false;
    }

    public override bool up()
    {
        return Input.GetMouseButtonUp(0);
    }
}
