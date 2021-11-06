using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    public float Health=10;
    [SerializeField]private float moveSpeed;
    [SerializeField]private float jumpSped;

    private action action;
    private AbState state;
    public void Setstate(AbState st)
    {
        this.state = st;
    }

    private void Awake()
    {
        action = gameObject.GetComponent<action>();
    }

    private void Start()
    {
        action.Vjump = jumpSped;
        action.Vmove = moveSpeed;
        Setstate(new AirState(this,this.action));
    }
    // Update is called once per frame
    void Update()
    {
        state.ActionMove();
        //action.Move();
        //action.jump();
        //action.Grab();
        //action.Dash();
        //Debug.Log(action.exvelocity);
        checkHp();
    }

    private void FixedUpdate()
    {
        action.CalWallGroundExV();
    }

    private void checkHp()
    {
        if (Health <= 0)
        {
            transform.position = new Vector2(-7.9f,-4.0f);
            Health = 10;
        }

    }
}
