using UnityEngine;
using DG.Tweening;
using System.Collections;

public class GhostTrail : MonoBehaviour
{
    private Rigidbody2D move;
    //private AnimationScript anim;
    private SpriteRenderer sr;
    public Transform ghostsParent;
    public Color trailColor;
    public Color fadeColor;
    public float ghostInterval;
    public float fadeTime;
    

    private void Start()
    {
        //anim = FindObjectOfType<AnimationScript>();
        move = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void ShowGhost()
    {
        Sequence s = DOTween.Sequence();

        for (int i = 0; i < ghostsParent.childCount; i++)
        {
            Transform currentGhost = ghostsParent.GetChild(i);
            //Color c = currentGhost.GetComponent<SpriteRenderer>().color;
            //currentGhost.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, 80);
            //s.AppendCallback(() => currentGhost.GetComponent<SpriteRenderer>().flipX = anim.sr.flipX);
            s.AppendCallback(() => currentGhost.position = move.transform.position);
            s.AppendCallback(() => currentGhost.GetComponent<SpriteRenderer>().sprite = sr.sprite);
            s.Append(currentGhost.GetComponent<SpriteRenderer>().DOColor(trailColor, 0));
            //currentGhost.GetComponent<SpriteRenderer>().material = GetComponent<SpriteRenderer>().material;
            s.AppendCallback(() => FadeSprite(currentGhost));
            s.AppendInterval(ghostInterval);
            //Debug.Log(currentGhost.transform.position);
            //StartCoroutine(fade(currentGhost.gameObject, 0.3f));
        }
    }

    public void FadeSprite(Transform current)
    {
        current.GetComponent<SpriteRenderer>().DOKill();
        current.GetComponent<SpriteRenderer>().DOColor(fadeColor, fadeTime);
        //current.GetComponent<SpriteRenderer>().material = GetComponent<SpriteRenderer>().material;
        //StartCoroutine(fade(current.gameObject,1f));
        
    }

    //IEnumerator fade(GameObject obj,float Tfade)
    //{
    //    Color c = obj.GetComponent<SpriteRenderer>().color;
    //    float t = Time.time;
    //    while (Time.time - t < Tfade)
    //    {
    //        Debug.Log(obj.GetComponent<SpriteRenderer>().color);
    //        obj.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, Mathf.Lerp(c.a,0,(Time.time-t)/Tfade));
    //        yield return null;

    //    }
    //    obj.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b,0);
    //}
}

