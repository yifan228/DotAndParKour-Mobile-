using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CreateBulletFactory<T> where T:AbBullete,new() 
{

    public static void ReturnBullete(GameObject thebullete,Vector2 dir,float dam,float _permeability)
    {
        T bullete = thebullete.GetComponent<T>();
        //bullete.Direction = dir;
        bullete.transform.up = dir;//直接轉子彈的座標
        bullete.Direction = new Vector2(0,1f);
        bullete.Damage = dam;
        bullete.Permeability = _permeability;
    }
}
