using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ScaleBounceTest : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    Sequence s;
    int num = 0;
    bool startAnim;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(num == 0)
        {
            s = DOTween.Sequence();
            s.Append(this.transform.DOScale(new Vector3(.5f, .5f, 0), 0.2f)).Append(this.transform.DOScale(new Vector3(1.5f, 1.5f, 0), 0.2f)).Append(this.transform.DOScale(new Vector3(1f, 1f, 0), 0.1f)).SetLoops(-1,LoopType.Restart);
        }
        num ++;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        s.Kill();
        transform.localScale = new Vector3(1, 1, 1);
        num = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
