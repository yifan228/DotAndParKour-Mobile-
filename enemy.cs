using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    CreateEnemy enmyFactor;
    public int Lv;//初始化speed health
    private float speed ;
    
    GameObject target;
    public GameObject Target { get => target; set => target = value; }

    public bool activate =true;

    //private int direction;
    //public int Direction { get => direction; set => direction = value; }

    private float health;
    public float Health { get => health; set => health = value; }
    
    //酒菜死亡後，玩家獲得多少錢
    [SerializeField]private int myValue=1;


    //public virtual void instantiateSpeedHp(ref int hp,int lv,ref float spd)
    //{
    //    health = hp;
    //    Lv = lv;
    //    speed = spd;
    //}

    public void instantiate(float speedRatio,float hpRatio)
    {
        speed = Lv*speedRatio;
        health = Lv * hpRatio ;
    }
    void Start()
    {
        //direction = 0;
    }
   
    void LateUpdate()
    {
        if (activate)
        {
            //DecideDirectoin(direction);
            Move();
        }

        if (health <= 0)
        {
            GameManager.instance.Money +=1+(int)( myValue*Lv*0.4f);
            GameManager.instance.OnBroadCastMoney();
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Time.deltaTime*speed);
    }

}