using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulleteOne : AbBullete   //這裡比較像演算法的實作
{
    public BulleteOne() : base(){ }
    public void Shoot(Vector2 vector)
    {
        //if (shooted)
        //{
        transform.Translate(vector.normalized * Speed);

        //}
    }
    private void FixedUpdate()
    {
        Shoot(direction);
    }

    private void Start()
    {
        //DontDestroyOnLoad(gameObject);
        //Destroy(gameObject, 0.3f);
        
    }
}
