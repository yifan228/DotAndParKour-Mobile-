using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalProjectile : MonoBehaviour
{
    [HideInInspector]public UIDrag uiDrag;

    [SerializeField] public GameObject range;

    [SerializeField]LayerMask Lm;
    ContactFilter2D ContactFilter2D;
    Collider2D[] ColResults = new Collider2D[5];//目前是隨便設一個數自儲存

    //傳canplace到uidrag
    //因為不想綁rigidbody2d所以不想用以下的方法判斷是否能放置坦克
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if(collision.tag is "CantPlaceRange")
    //    {
    //        uiDrag.canPlace = false;
    //        range.GetComponent<SpriteRenderer>().color = Color.red;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag is "CantPlaceRange")
    //    {
    //        uiDrag.canPlace = true;
    //        range.GetComponent<SpriteRenderer>().color = Color.white;
    //    }
    //}
    // Start is called before the first frame update
    void Start()
    {
        ContactFilter2D = new ContactFilter2D();
        ContactFilter2D.SetLayerMask(Lm);
        
    }

    // Update is called once per frame
    void Update()
    {
        int tmp = gameObject.GetComponent<CircleCollider2D>().OverlapCollider(ContactFilter2D,ColResults);
        
        if(tmp==0)
        {
            uiDrag.canPlace = true;
            range.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.3f);
            //Debug.Log("CanPlace");
        }
        else
        {
            uiDrag.canPlace = false;
            range.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.3f);
            //Debug.Log("CanttttPlace");
        }
    }
}
