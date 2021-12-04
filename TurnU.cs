using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnU : MonoBehaviour
{
    public GameObject next=null;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if(next!=null&&Vector2.Distance(transform.position,collision.transform.position)<=0.1)
                collision.GetComponent<enemy>().Target = next;
        }
    }
}
