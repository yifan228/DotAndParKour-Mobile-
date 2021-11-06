using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   // 金錢 敵人開場的等級

    // singleton instance
    public static GameManager instance;
    //Lv
    public int Lv;
    //Money
    public int Money { get; set; } = 40;
    [SerializeField] private Text moneytext;

    //Link To Gamesystem
    GameSystem sys;
    public GameSystem Sys { get => sys; set => sys = value; }

    //link to the enemy weapon factory
    [SerializeField] CreateWeaponSys weponFactory;
    [SerializeField] CreateEnemy enemyFactory;

    //round1 2 3...
    private int round;

    //broadcast setlv setmoney
    public event EventHandler<int> BroadcastLv;

    public void OnBroadcastEnemyMaxLv()
    {
        BroadcastLv = null;
        BroadcastLv += enemyFactory.SetLvFromBroCast;
        BroadcastLv(this, Lv);
    }
    //public void OnBroadcastWeaponFacLv()
    //{
    //    BroadcastLv = null;

    //    BroadcastLv += weponFactory.SetLvFromBrocast;
    //    BroadcastLv(this, Lv);
    //}


    public event EventHandler<int> BroadCastMoney;
    public void OnBroadCastMoney()
    {
        BroadCastMoney += enemyFactory.SetMoneyFromBrocast;
        BroadCastMoney += weponFactory.SetMoneyFromBrocast;
        BroadCastMoney(this, Money);
        moneytext.text = $"{Money}";
        //Debug.Log(Money);
    }

    private void Awake()
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

    private void Start()
    {
        OnBroadcastEnemyMaxLv();
        Invoke("OnBroadCastMoney",0.3f);
    }

    //store the tower info
    private void StoreTowerInfo()
    {
        GameObject[] tws = GameObject.FindGameObjectsWithTag("Tower");
        foreach (GameObject tw in tws)
        {
            Sys.Towers.Add(tw);
            //sys.Towerspos.Add(tw.transform.position);
        }
    }
}
