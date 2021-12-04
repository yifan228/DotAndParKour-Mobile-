using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootheBlock : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject Block;
    [SerializeField] Transform point;
    //[SerializeField] LayerMask layerMask;
    //ContactFilter2D filter;
    //RaycastHit2D[] hits;
    [SerializeField]int HorizontalOrVerticalnum;

    private int blockamount=0;
     int BlockMaxamount=6;

    //bool isactive;

    private void Start()
    {
        //filter = new ContactFilter2D();
        //filter.SetLayerMask(layerMask);
        //hits = new RaycastHit2D[1];
    }

    void Update()
    {
        if (transform.position.x < -7f ||transform.position.x >7)
        {
            transform.position = new Vector2(-1, 4.875f);
        }
        if (Inputclick0())
        {
            if(HorizontalOrVerticalnum == 1)
            {
                //int hitnum = Physics2D.CircleCast(MouseInput(), 0.1f, Vector2.zero,filter,hits);
                if (!YrangeBigger(InputPos()))
                {
                    transform.position = new Vector2(InputPos().x,transform.position.y);
                }else
                {
                    //Debug.DrawLine(transform.position, InputPos(),Color.green);
                    return;
                }
            }else if (HorizontalOrVerticalnum == 2)
            {

            }

        }
        if (InputClickUp() && blockamount < BlockMaxamount)
        {
            //Debug.Log("mouseup");
            GameObject obj = Instantiate(Block,point.position,Quaternion.identity);
            obj.GetComponent<AIBlock>().direction = Vector3.Normalize(InputPos() - (Vector2)transform.position);
            blockamount++;
        }else if (blockamount == BlockMaxamount)
        {
            Destroy(gameObject);
        }
    }

    public virtual bool Inputclick0()
    {
        return Input.GetMouseButton(0);
    }
    public virtual bool InputClickUp()
    {
        return Input.GetMouseButtonUp(0);
    }

    public virtual Vector2 InputPos()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    bool YrangeBigger(Vector2 vector2)
    {
        return Mathf.Abs(vector2.y - transform.position.y)>=1;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, transform.position + Vector3.down);
    //}
}
