using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MyPlayer : MonoBehaviour
{
    [SerializeField] GameObject dialog;
    [SerializeField] Text tx;
    public float Health;
    [SerializeField] float HealthMax;
    private Image healthFilled;

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
        Health = HealthMax;
        healthFilled = GameObject.Find("HpFilled").GetComponent<Image>();
    }

    private void Start()
    {
        action.Vjump = jumpSped;
        action.Vmove = moveSpeed;
        Setstate(new AirState(this,this.action));
        Sequence s = DOTween.Sequence();
        s.AppendInterval(1).Append(tx.DOText("我怎麼", 1).SetEase(Ease.Linear)).AppendInterval(1f).Append(tx.DOText("", 0.1f))
            .Append(tx.DOText("變成菜了", 1f).SetEase(Ease.Linear)).AppendInterval(1f).Append(tx.DOText("", 0.1f))
            .Append(tx.DOText("嗚嗚嗚", 2)).Append(tx.DOText("", 0.1f)).Append(tx.DOText("無法", 1f).SetEase(Ease.Linear)).Append(tx.DOText("思考", 1f).SetEase(Ease.Linear))
            .Append(tx.DOText("有...", 2f)).Append(tx.DOText("", 0.1f).SetEase(Ease.Linear)).Append(tx.DOText("有酒嗎", 2f).SetEase(Ease.Linear)).
            Append(tx.DOText("", 0.1f)).Append(tx.DOText("酒...", 2.5f)).Append(tx.DOText("", 0.1f)).
            Append(tx.DOText("<color=red>上方紅點</color>",1f,true)).AppendInterval(0.5f).Append(tx.DOText("",0.1f)).Append(tx.DOText("能拖曳嗎",1f)).
            Append(tx.DOText("......",1f)).AppendInterval(1f).Append(tx.DOText("",0.1f)).
            Append(tx.DOText("右上方\n.....", 2f))
            .Append(tx.DOText("", 0.1f)).Append(tx.DOText("酒......", 2.5f))
            .AppendCallback(() => dialog.SetActive(false));
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
        healthFilled.fillAmount = Health/HealthMax;
        if (Health <= 0)
        {
            transform.position = new Vector2(-7.9f,-4.0f);
            Health = HealthMax;
        }

    }
}
