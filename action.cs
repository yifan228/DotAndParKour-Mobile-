using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class action : MonoBehaviour
{   //要用startcourutine必須繼承monobehaviour，而monobehaviour不能用new關鍵字生成，必須掛在遊戲物件上初始畫
    //public action(Rigidbody2D mychar) { _myChar = mychar; }
    [SerializeField] private float fallDownSpeed = -0f;

    public Vector2 exvelocity;//外力給的速度
    [SerializeField] bool isGrabing;

    protected float vjump;
    public float Vjump { get => vjump; set => vjump = value; }

    protected float vmove;
    public float Vmove { get => vmove; set => vmove = value; }

    public Rigidbody2D _myChar;
    [SerializeField] private Rigidbody2D ground;
    [SerializeField] private Rigidbody2D wall;

    [SerializeField]ParticleSystem parsys;

    GameObject dashColdTimeObject;
    Image dashColdTimeImage;
    protected virtual void Awake()
    {
        dashColdTimeObject = GameObject.Find("DashColdTime");
        dashColdTimeImage = dashColdTimeObject.GetComponent<Image>();
        dashColdTimeObject.SetActive(false);
        _myChar = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        ground = null;
        //CalWallGroundExV();
        if (Canmove())
        {
            if (InputRight() && (!CanGrabRit()||!IsFeetGroundRit()))
            {
                _myChar.velocity = new Vector2(1f * Vmove + exvelocity.x, _myChar.velocity.y);
            }
            else if (InputLeft() && (!CanGrabLeft()||!IsFeetGroundLeft()))
            {
                _myChar.velocity = new Vector2(-1f * Vmove + exvelocity.x, _myChar.velocity.y);
            }
            else if (isground())
            {
                _myChar.velocity = exvelocity;
            }
        }

        //Debug.DrawLine(_myChar.transform.position, _myChar.transform.position - new Vector3(0.15625f,0), Color.green);
    }

    protected virtual bool InputRight()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }

    protected virtual bool InputLeft()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    public bool Canmove()
    {
        //if (!isground())
        //    return false;
        //這樣很難玩

        return true;
        //補raycasthit
    }

    public void CalWallGroundExV()
    {
        exvelocity = Vector2.zero;
        if (isground())
        {
            exvelocity += ground.velocity;
        }

        if (CanGrabLeft() || CanGrabRit())
        {
            exvelocity += wall.velocity;
        }

    }

    bool jumpIscolding=false;
    public void jump()
    {
        if (canjump())
        {
            if (InputGroundJump()&&!jumpIscolding)
            {
                //CalWallGroundExV();
                _myChar.velocity = new Vector2(exvelocity.x, 1f * Vjump + exvelocity.y);
                StartCoroutine(jumpcolding());
            }
        }
    }

    protected virtual bool InputGroundJump()
    {
        return Input.GetKey(KeyCode.Space);
    }

    protected virtual bool InputJump()
    {
        return Input.GetKey(KeyCode.Space);
    }

    private bool canjump()
    {
        ground = null;
        bool tmp = false;
        if (isground())
        {
            tmp = true;
        } else if (isGrabing)
        {
            tmp = true;
        }

        return tmp;
    }

    IEnumerator jumpcolding()
    {
        float t0 = Time.time;
         jumpIscolding = true;
        while (Time.time - t0 <= 0.3f)
        {
            yield return null;
        }
        jumpIscolding = false;
    }

    public void Grab()
    {
        wall = null;
        if (CanGrabRit() || CanGrabLeft())
        {
            //if (InputGrab())
            //{
                //_myChar.gravityScale = 0;
                //CalWallGroundExV();
                //Debug.Log("grab");
                AnyAdditionAction();
            //}
            //else
            //{
                //_myChar.gravityScale = 1;
            //}
        }else if (IsFeetGroundRit() || IsFeetGroundLeft())
        {
            if (InputJump())
            {
                FindObjectOfType<GhostTrail>().ShowGhost();
                _myChar.velocity = new Vector2(exvelocity.x, 3f + exvelocity.y);
                //Debug.Log("thisIsWallClimb");

            }
            //爬牆到最後的跳
            //_myChar.gravityScale = 1;
           
        }
        
    }

    protected virtual bool InputGrab()
    {
        return Input.GetKey(KeyCode.C);
    }
    //for state
    public bool InputTriggergrab()
    {
        return InputGrab();
    }


    public void AnyAdditionAction()
    {
        if (InputJump())
        {
            if (InputLeft())
            {
                //蹬牆跳
                if (!CanGrabLeft())
                {
                    FindObjectOfType<GhostTrail>().ShowGhost();
                    _myChar.velocity = new Vector2(-1f+exvelocity.x, 1f * Vjump + exvelocity.y);
                }else if (InputJump()&&!jumpIscolding)
                {
                    _myChar.GetComponent<Transform>().position += new Vector3(0, 0.3f, 0);
                    StartCoroutine(jumpcolding());
                }
            }else if (InputRight())
            {
                if (!CanGrabRit())
                {
                    FindObjectOfType<GhostTrail>().ShowGhost();
                    _myChar.velocity = new Vector2(1f + exvelocity.x, 1f * Vjump + exvelocity.y);
                }
                else if (InputJump() && !jumpIscolding)
                {
                    _myChar.GetComponent<Transform>().position += new Vector3(0, 0.2f, 0);
                    StartCoroutine(jumpcolding());
                }
            }
            else if(!jumpIscolding)
            {
                _myChar.GetComponent<Transform>().position += new Vector3(0, 0.2f, 0);
                StartCoroutine(jumpcolding());
            }
        }
        else
        {
            _myChar.velocity = new Vector2(exvelocity.x, -fallDownSpeed + exvelocity.y);

        }
    }
    
    public void Dash()
    {
        if (InputDash() && canDash())
        {
            StartCoroutine(dashing(0.3f,8));//(dashTime,dashSpeed)
            StartCoroutine(dashcoldtime(2f));//(dashColdTime)
        }
    }

    protected virtual bool InputDash()
    {
        return Input.GetKeyDown(KeyCode.X);
    }

    private bool canDash()
    {
        if(dashTimeDone)
            return true;
        return false;
    }
    IEnumerator dashing(float dashingTIme,int speed)
    {
        Vector2 vec = _myChar.velocity;
        float initialtime = Time.time;
        Vector2 direction = _myChar.velocity;
        //dasheffect
        Camera.main.transform.DOComplete();
        Camera.main.transform.DOShakePosition(0.2f,0.5f,14,90,false,true);
        FindObjectOfType<RippleEffect>().Emit(Camera.main.WorldToViewportPoint(transform.position));
        FindObjectOfType<GhostTrail>().ShowGhost();
        //parsys.Play();
        ///
        while (Time.time - initialtime < dashingTIme)
        {
            //if (canGrabLeft() || canGrabRit() || isground()) break;
            _myChar.position =new Vector2(Mathf.Lerp(transform.position.x, transform.position.x+Vector3.Normalize(direction).x*speed, Time.deltaTime),
                Mathf.Lerp(transform.position.y, transform.position.y+Vector3.Normalize(direction).y*speed, Time.deltaTime));
            yield return null;
        }        
        _myChar.velocity = vec;
    }
    bool dashTimeDone=true;
    IEnumerator dashcoldtime(float ctime)
    {
        dashColdTimeObject.SetActive(true);
        dashColdTimeImage.fillAmount = 1f;
        float initialtime = Time.time;
        while (Time.time-initialtime<ctime)
        {
            dashTimeDone = false ;
            //加上冷卻倒數的動畫
            dashColdTimeImage.fillAmount =1f- (Time.time - initialtime )/ ctime;
            yield return null;
        }
        dashTimeDone = true;
        dashColdTimeObject.SetActive(false);
    }

    //private bool isHit(Vector3 origin,Vector2 dir,float distance,string tag)
    //{
    //    bool tmp = false;
    //    RaycastHit2D[] hits = Physics2D.RaycastAll(origin,dir,distance);
    //    foreach (RaycastHit2D hit in hits)
    //    {
    //        if (hit.collider.tag == tag)
    //        {
    //            tmp = true;
    //            return tmp;
    //        }
    //    }
    //    return tmp;
    //}

    public bool isground()//偵測 tag : Ground
    {
        bool tmp=false;
        RaycastHit2D[] hits = Physics2D.RaycastAll(_myChar.transform.position+ new Vector3(0,_myChar.GetComponent<BoxCollider2D>().size.y*_myChar.transform.localScale.y / 2,0), Vector2.down , _myChar.GetComponent<BoxCollider2D>().size.y * _myChar.transform.localScale.y / 2+0.05f);
        foreach(RaycastHit2D hit in hits)
        {
            if(hit.collider.tag is "Ground")
            {
                tmp = true;
                ground = hit.rigidbody;
                return tmp;
            }
            //return tmp;
        }
        RaycastHit2D[] hits2 = Physics2D.RaycastAll(_myChar.transform.position + new Vector3(0, _myChar.GetComponent<BoxCollider2D>().size.y * _myChar.transform.localScale.y / 2, _myChar.GetComponent<BoxCollider2D>().size.x * _myChar.transform.localScale.x / 2), Vector2.down, _myChar.GetComponent<BoxCollider2D>().size.y * _myChar.transform.localScale.y / 2 + 0.05f);
        foreach (RaycastHit2D hit in hits2)
        {
            if (hit.collider.tag is "Ground")
            {
                tmp = true;
                ground = hit.rigidbody;
                return tmp;
            }

            //return tmp;
        }
        RaycastHit2D[] hits3 = Physics2D.RaycastAll(_myChar.transform.position + new Vector3(0, _myChar.GetComponent<BoxCollider2D>().size.y * _myChar.transform.localScale.y / 2,-_myChar.GetComponent<BoxCollider2D>().size.x * _myChar.transform.localScale.x / 2), Vector2.down, _myChar.GetComponent<BoxCollider2D>().size.y * _myChar.transform.localScale.y / 2 + 0.05f);
        foreach (RaycastHit2D hit in hits2)
        {
            if (hit.collider.tag is "Ground")
            {
                tmp = true;
                ground = hit.rigidbody;
                return tmp;
            }

            //return tmp;
        }

        return tmp;
    }

    public bool CanGrabRit()//偵測 tag : Ground Tower
    {
        bool tmp = false;
        RaycastHit2D[] hits = Physics2D.RaycastAll(
            _myChar.transform.position + new Vector3(0, _myChar.GetComponent<BoxCollider2D>().size.y * _myChar.transform.localScale.y / 2, 0),
            Vector2.right, _myChar.GetComponent<BoxCollider2D>().size.x * _myChar.transform.localScale.x / 2 + 0.05f);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.tag is "Ground"|| hit.collider.tag is "Tower")
            {
                tmp = true;
                wall = hit.rigidbody;
                return tmp;
            }
         
        }
        RaycastHit2D[] hits2 = Physics2D.RaycastAll(_myChar.transform.position + new Vector3(0, _myChar.GetComponent<BoxCollider2D>().size.y * _myChar.transform.localScale.y, 0),
            Vector2.right, _myChar.GetComponent<BoxCollider2D>().size.x * _myChar.transform.localScale.x/ 2 + 0.05f);
        foreach (RaycastHit2D hit in hits2)
        {
            if (hit.collider.tag is "Ground" || hit.collider.tag is "Tower")
            {
                tmp = true;
                wall = hit.rigidbody;
                return tmp;
            }
           

        }
        return tmp;
    }

        //右腳邊的牆
    public bool IsFeetGroundRit()
    { 
        RaycastHit2D[] hits3 = Physics2D.RaycastAll(_myChar.transform.position, Vector2.right, _myChar.GetComponent<BoxCollider2D>().size.x * _myChar.transform.localScale.x / 2 + 0.05f);
        foreach (RaycastHit2D hit in hits3)
        {
            if (hit.collider.tag is "Ground")
            {
                return true;
            }
        }
        return false;
    }
    public bool CanGrabLeft()
    {
        bool tmp = false;
        RaycastHit2D[] hits = Physics2D.RaycastAll(_myChar.transform.position + new Vector3(0, _myChar.GetComponent<BoxCollider2D>().size.y * _myChar.transform.localScale.y / 2, 0), Vector2.left, _myChar.GetComponent<BoxCollider2D>().size.x * _myChar.transform.localScale.x / 2 + 0.05f);
        RaycastHit2D[] hits2 = Physics2D.RaycastAll(_myChar.transform.position + new Vector3(0, _myChar.GetComponent<BoxCollider2D>().size.y * _myChar.transform.localScale.y, 0), Vector2.left, _myChar.GetComponent<BoxCollider2D>().size.x * _myChar.transform.localScale.x / 2 + 0.05f);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.tag is "Ground" || hit.collider.tag is "Tower")
            {
                tmp = true;
                wall = hit.rigidbody;
                return tmp;
            } 

        }
        foreach (RaycastHit2D hit in hits2)
        {
            if (hit.collider.tag is "Ground" || hit.collider.tag is "Tower")
            {
                tmp = true;
                wall = hit.rigidbody;
                return tmp;
            }

        }
        return tmp;
    }
    //做腳邊的牆
    public bool IsFeetGroundLeft()
    {
        RaycastHit2D[] hits3 = Physics2D.RaycastAll(_myChar.transform.position, Vector2.left, _myChar.GetComponent<BoxCollider2D>().size.x * _myChar.transform.localScale.x / 2 + 0.05f);
        foreach (RaycastHit2D hit in hits3)
        {
            if (hit.collider.tag is "Ground")
            {
                return true;
            }

        }
        return false;
    }
}
