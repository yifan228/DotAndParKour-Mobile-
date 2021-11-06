using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mobileZoom : MonoBehaviour
{
    private InputUnitySys touchInput;
    private Coroutine zoomCorutine;

    [SerializeField] private Camera cmera;

    private void Awake()
    {
        
        touchInput = new InputUnitySys();
        touchInput.Touch.SescondFingerContact.started += _ => zoomStart();
        touchInput.Touch.SescondFingerContact.canceled += _ => zoomEnd();

        //touchInput.Touch.FirstContact.started += _ => test();
        //touchInput.Touch.FirstContact.canceled += _ => test2();
    }

    private void OnEnable()
    {
        touchInput.Enable();
    }

    private void OnDisable()
    {
        
        touchInput.Disable();
    }

    //void Srart()
    //{
    //    touchInput.Touch.SescondFingerContact.started += _ => zoomStart();
    //    touchInput.Touch.SescondFingerContact.canceled += _ => zoomEnd();

    //    touchInput.Touch.FirstContact.started += _ => test();
    //    touchInput.Touch.FirstContact.canceled+= _ => test2();
    //}

    public void test()
    {
        Debug.Log("heyf");
    }

    public void test2()
    {
        Debug.Log("fuckyuo");
    }

    public void zoomStart()
    {
        zoomCorutine = StartCoroutine(zoomCorutineEnumerator());
    }

    public void zoomEnd()
    {
        StopCoroutine(zoomCorutine);
    }

    IEnumerator zoomCorutineEnumerator()
    {
        float dis = 0, preDis = 0;
        while (true)
        {
            dis = Vector2.Distance(touchInput.Touch.FIrstFingerPos.ReadValue<Vector2>(), touchInput.Touch.SecondFingerPos.ReadValue<Vector2>());
            //zoomOUt
            //if(Vector2.Dot()<-0.9) 是否同向 
            if (dis > preDis)
            {
                Debug.Log("zoomUot");
                cmera.orthographicSize += 0.1f * Time.deltaTime*25;
            }
            else if (dis < preDis)
            {
                Debug.Log("zoomin");
                cmera.orthographicSize -= 0.1f * Time.deltaTime*25;
            }
            preDis = dis;
            yield return null;
        }
    }
}
