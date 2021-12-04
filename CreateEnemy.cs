using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    //Lv
    private int Lv = 1;

    private int MaxLv;
    public void SetLvFromBroCast(object Source, int lv)
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
    private bool canCreate = true;
    public bool CanCreate { get => canCreate; set => canCreate = value; }

    //儲存酒菜種類的list
    [SerializeField] List<GameObject> enemy;
    //要生成的酒菜
    GameObject NowEnemy;
    //用編號選曲要生成的酒菜
    private int whitchEnemy = 0;
    public int WhitchEnemy { get => whitchEnemy; set => whitchEnemy = value; }

    //instantiate spdratio hpratio (set in panel)
    public float SpeedRatio { get; set; }
    public float HpRatio { get; set; }

    //created enemy amount
    int enemyAmount = 1;//下一個要發射的是第一個

    //間隔時間
    float coldtime = 2.5f;
    //計時用的時間

    float timertime = 0;

    void Update()
    {
        //////DecideLv
        DecideLvMethod2();

        //// MaxLv(最後一個Lv)
        if (Lv > MaxLv)
        {
            canCreate = false;
            //Debug.Log(GameObject.FindGameObjectsWithTag("Enemy"));
            if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)// 不知道為啥if(GameObject.FindGameObjectsWithTag("Enemy") is null)不能用
            {
                GameManager.instance.TDWin();
                Destroy(gameObject);
            }
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
        if (timertime >= coldtime)
        {
            createEnemy();
            timertime = 0;
        }
    }

    protected virtual void createEnemy()
    {
        NowEnemy = enemy[whitchEnemy];//選擇哪種酒菜生成
        GameObject enmy = Instantiate(NowEnemy, transform.position, Quaternion.identity);
        enemy enmyenemy = enmy.GetComponent<enemy>();
        enmyenemy.Target = next;
        enmyenemy.Lv = this.Lv;
        enmyenemy.instantiate(SpeedRatio, HpRatio);//instantiate speed health
        enemyAmount++;
    }
    void DecideLvMethod2()
    {
        int enemyAmountDivideByTen = enemyAmount / 10;

        switch (enemyAmountDivideByTen)
        {
            case 0:
                Lv = 1;
                break;
            case 1:
                Lv = 2;
                break;
            case 2:
                {
                    Lv = 3;
                    coldtime= 2.5f;
                    break;
                }
            case 3:
                Lv = 4;
                break;
            case 4:
            case 5:
                Lv = 5;
                break;
            case 6:
            case 7:
                {
                    Lv = 6;
                    coldtime= 2f;
                    break;
                }
            case 8:
            case 9:
                Lv = 7;
                break;
            case 10:
            case 11:
                Lv = 8;
                break;
            case 12:
            case 13:
                {
                    Lv = 9;
                    coldtime= 1.5f;
                    break;
                }
            case 14:
            case 15:
                Lv = 10;
                break;
            default:
                Lv = 100;
                break;
        }
    }
}