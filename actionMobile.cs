using System;
using UnityEngine;
using UnityEngine.UI;


public class actionMobile:action
{
    public actionMobile():base() { }

    [SerializeField] Joystick joystick;
    int dashnum;
    [SerializeField] GameObject dashbtn;
    [SerializeField] GameObject grabbtn;
    [Header("sensitivity")] [SerializeField] [Range(0,1)]float sensitive =1;

    protected override void Awake()
    {
        base.Awake();
        dashbtn = GameObject.Find("dash");
        grabbtn = GameObject.Find("grab");
    }

    protected override bool InputDash()
    {
        return dashbtn.GetComponent<ButtonIsDown>().IsDown;
    }

    protected override bool InputGrab()
    {
        return grabbtn.GetComponent<ButtonIsDown>().IsDown;
    }

    protected override bool InputJump()
    {
        return joystick.Vertical > 0.5f*sensitive;
    }

    protected override bool InputLeft()
    {
        return joystick.Horizontal <- 0.2f*sensitive;
    }

    protected override bool InputRight()
    {
        return joystick.Horizontal > 0.2f*sensitive;
    }

}
