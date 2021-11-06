using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public abstract class ClickManager :MonoBehaviour
{
    //public bool CanCLick;
    public GameObject target=null;

    public abstract Vector2 ClickPos();

    public void TargetMove()
    {
        target.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(ClickPos());
    }

    public void getTarget()
    {
        if (downClick())
        {
            RaycastHit2D hit = Physics2D.CircleCast((Vector2)Camera.main.ScreenToWorldPoint(ClickPos()), 0.3f, Vector2.zero);
            if(hit==true && hit.collider.tag is "Tower")//用等於等於hit底下會有點點，要先確認有hit到東西才不會跑出還沒referenceNullExeption的警告
            {
                target = hit.collider.gameObject;
            }else
            {
                target = null;
            }
        }

        if (up())
        {
            target = null;
        }
    }

    private void Update()
    {
        if (target == null)
        {
            getTarget();
        }

        if (target!=null && target.GetComponent<WeaponAttr>().Canclick && down())
        {
            TargetMove();
        }

        if (target!= null && up())
        {
            target.GetComponent<WeaponAttr>().Canclick = false;
            target = null;
        }
    }

    
    public abstract bool hover();
    public abstract bool downClick();
    public abstract bool down();
    public abstract bool up();
}
