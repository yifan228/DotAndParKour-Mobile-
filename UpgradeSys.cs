using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSys : MonoBehaviour
{
    public static UpgradeSys instance;
    public GameObject Canvas;
    public AbWeapon clickedTank;
    [SerializeField] Text tankStat;
    [SerializeField] Text upgradeLvCost;
    [SerializeField] Text upgradeColdTimeCost;
    //(set in panel)
    public float CTimeDRatio { get; set; }
    public int LvUpCostRatio { get; set; }
    //
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TankUpgrade()
    {
        //upgrade
        if (GameManager.instance.Money >= LvMoneyCost() * clickedTank.TankLV)
        {
            GameManager.instance.Money -= LvMoneyCost()*clickedTank.TankLV;
            clickedTank.TankLV++;
            GameManager.instance.OnBroadCastMoney();

        }
    }

    public void TankColdTime()
    {
        if (GameManager.instance.Money >= Mathf.RoundToInt(CtimeMoneyCost(clickedTank) / clickedTank.ColdTime) && clickedTank.ColdTime>0.2f)
        {
            GameManager.instance.Money -= Mathf.RoundToInt(CtimeMoneyCost(clickedTank) / clickedTank.ColdTime);
            clickedTank.ColdTime -=CTimeDRatio;
            GameManager.instance.OnBroadCastMoney();
        }
    }

    public void cancel()
    {
        clickedTank = null;
        Canvas.SetActive(false);
    }

    private void Update()
    {
        if (clickedTank != null)
        {
            tankStat.text = clickedTank.GetComponentInParent<Rigidbody2D>().name.ToString()+"\n" +"Lv : " + clickedTank.TankLV + "\n"+"ColdTime : "+clickedTank.ColdTime;
            upgradeLvCost.text = "Cost : " + (clickedTank.TankLV * LvMoneyCost()).ToString();
            upgradeColdTimeCost.text ="Cost : " + $"{Mathf.RoundToInt(CtimeMoneyCost(clickedTank) / clickedTank.ColdTime)}";
            //Debug.Log(clickedTank.GetComponentInParent<Rigidbody2D>().tag);

        }
    }

    int LvMoneyCost()
    {
        return LvUpCostRatio;
    }

    int CtimeMoneyCost(AbWeapon tank)
    {
        if(tank is shootWeapon)
        {
            return 8;
        }else if(tank is shootweaponFast)
        {
            return 4;
        }
        else
        {
            return 200;
        }
    }
}
