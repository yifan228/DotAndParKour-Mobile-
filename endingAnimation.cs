using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class endingAnimation : MonoBehaviour
{
   

    Sequence s;
    GameObject cam;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        text =  GameObject.Find("MainText").GetComponent<Text>();
        StartCoroutine(anim());
        //s.Append(text.DOText("...", 1f))
        //    .PrependInterval(1)
        //.AppendCallback(cameraShake)
        //.AppendCallback(() => text.color = Color.black)
        //.PrependInterval(1f)
        //.Append(Camera.main.DOColor(Color.white, 0.5f))
        //.Append(text.DOText("是夢嗎？", 1.5f))
        //.AppendInterval(1f)
        //.Append(text.DOText("真是可笑啊", 2f))
        //.AppendInterval(1f)
        //.Append(text.DOText("身為人類，竟然夢到自己變成酒菜", 4f))
        //.AppendInterval(1f)
        //.Append(text.DOText("不過剛才的感受倒也挺真實的", 3.5f))
        //.AppendInterval(1f)
        //.AppendCallback(cameraShake)
        //.AppendInterval(0.5f)
        //.Append(text.DOText("等等", 0.2f))
        //.AppendInterval(0.5f)
        //.Append(text.DOText("還是說現在的我才是在夢中", 4.5f))
        //.AppendInterval(1f)
        //.Append(text.DOText("其實我是一顆酒菜！！", 3f))
        //.AppendInterval(1f)
        //.Append(text.DOText("夢到自己變成了人類！！", 3f))
        //.AppendInterval(3f)
        //.Append(text.DOText("算了，有時間想這些，不如早點去上班", 3f));

    }

    IEnumerator anim()
    {
        
        s.Append(text.DOText("...", 2f));
        yield return new WaitForSeconds(2f);
        cameraShake();
        yield return new WaitForSeconds(1f);
        text.text = null;
        s.Append(Camera.main.DOColor(Color.white, 0.5f));
        yield return new WaitForSeconds(0.5f);
        text.color = Color.black;
        s.Append(text.DOText("是夢嗎？", 1.5f));
        yield return new WaitForSeconds(2.5f); text.text = null;
        s.Append(text.DOText("真是可笑啊", 2f)); yield return new WaitForSeconds(3f);
        s.Append(text.DOText("身為人類，竟然夢到自己變成酒菜", 4f)); yield return new WaitForSeconds(5f); text.text = null;
        
        s.Append(text.DOText("不過剛才的感受倒也挺真實的", 3.5f)); yield return new WaitForSeconds(4.5f);
        text.text = null;
        cameraShake();
        s.Append(text.DOText("等等", 0.2f)); yield return new WaitForSeconds(1f);
        s.Append(text.DOText("還是說現在的我才是在夢中", 4.5f)); yield return new WaitForSeconds(5.5f); text.text = null;
        s.Append(text.DOText("其實我是一顆酒菜！?", 3f)); yield return new WaitForSeconds(4f); text.text = null;
        s.Append(text.DOText("夢到自己變成了人類！！", 3f)); yield return new WaitForSeconds(4); text.text = null;
        s.Append(text.DOText("算了，有時間想這些，不如早點去上班", 3f)); yield return new WaitForSeconds(4); text.text = null;
    }

    void cameraShake()
    {
        cam.GetComponent<ScreenShake>().Shake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
