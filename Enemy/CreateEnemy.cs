using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    //Lv
    private int Lv=1;

    private int MaxLv;
    public void SetLvFromBroCast(object Source,int lv )
    {
        MaxLv = lv;
        //Debug.Log("enemySetLv");
    }

    //指揮官目前有的錢
    private int money;
    public int Money { get => money; set => money = value; }
    public void SetMoneyFromBrocast(object Source, int mony)
    {
        money = mony;
    }

    //酒菜要去的第一個地方（轉角）
    public GameObject next;

    //createEnemyFactory是否要運作
    private bool canCreate=true;
    public bool CanCreate { get => canCreate; set => canCreate = value; }

    //儲存酒菜種類的list
    [SerializeField] List<GameObject> enemy;
    //要生成的酒菜
    GameObject NowEnemy;
    //用編號選曲要生成的酒菜
    private int whitchEnemy =0;
    public int WhitchEnemy { get => whitchEnemy; set => whitchEnemy = value; }

    //instantiate spdratio hpratio (set in panel)
    public float SpeedRatio { get; set; }
    public float HpRatio { get; set; }

    //created enemy amount
    int enemyAmount=1;//下一個要發射的是第一個

    //間隔時間
    float coldtime = 2.5f;
    //計時用的時間
     
    float timertime =0;

    void Update()
    {
        //////DecideLv
        DecideLv();

        //// MaxLv(最後一個Lv)
        if (Lv > MaxLv)
        {
            Debug.Log(enemyAmount);
            canCreate = false;

        }
        //////
        if (canCreate)
        {
            timeInterval();
        }
    }


    private void timeInterval()
    {
        timertime += Time.deltaTime;
        if(timertime >= coldtime)
        {
            createEnemy();
            timertime = 0;
        }
    }

    protected virtual void createEnemy()
    {   
        NowEnemy = enemy[whitchEnemy];//選擇哪種酒菜生成
        GameObject enmy= Instantiate(NowEnemy,transform.position,Quaternion.identity);
        enemy enmyenemy = enmy.GetComponent<enemy>();
        enmyenemy.Target = next;
        enmyenemy.Lv = this.Lv;
        enmyenemy.instantiate(SpeedRatio,HpRatio);//instantiate speed health
        enemyAmount++;
    }
    private void DecideLv()
    {
        if (enemyAmount >= 0 && enemyAmount <= 10)
        {
            Lv = 1;
        }
        else if (enemyAmount >= 11 && enemyAmount <= 20)
        {
            Lv = 2;
        }
        else if (enemyAmount >= 21 && enemyAmount <= 30)
        {
            Lv = 3;
            coldtime = 2.5f;
        }
        else if (enemyAmount >= 31 && enemyAmount <= 40)
        {
            Lv = 4;
        }
        else if (enemyAmount >= 41 && enemyAmount <= 60)
        {
            Lv = 5;
        }
        else if (enemyAmount >= 61 && enemyAmount <= 80)
        {
            coldtime = 2;
            Lv = 6;
        }
        else if (enemyAmount >= 81 && enemyAmount <= 100)
        {
            Lv = 7;
        }
        else if (enemyAmount >= 101 && enemyAmount <= 120)
        {
            Lv = 8;
        }
        else if (enemyAmount >= 121 && enemyAmount <= 140)
        {
            coldtime = 1f;
            Lv = 9;
        }
        else if (enemyAmount >= 141 && enemyAmount<=160)
        {
            Lv = 10;
        }
        else { Lv = 100; }
    }
}
