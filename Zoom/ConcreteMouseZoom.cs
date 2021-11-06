using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteMouseZoom : Zoom
{
    protected override float GetNext()
    {
        return Input.mouseScrollDelta.y;
    }
}
